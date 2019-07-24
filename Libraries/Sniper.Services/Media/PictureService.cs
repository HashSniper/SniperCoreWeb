using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Microsoft.AspNetCore.Http;
using Sniper.Core;
using Sniper.Core.Data;
using Sniper.Core.Domain.Catalog;
using Sniper.Core.Domain.Media;
using Sniper.Core.Infrastructure;
using Sniper.Data;
using Sniper.Services.Catalog;
using Sniper.Services.Configuration;
using Sniper.Services.Events;
using Sniper.Services.Seo;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.Primitives;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Formats;
using System.IO;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Bmp;
using SixLabors.ImageSharp.Formats.Gif;
using SixLabors.ImageSharp.Formats.Png;
using System.Linq;

namespace Sniper.Services.Media
{
    public partial class PictureService : IPictureService
    {
        #region Fields

        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IDownloadService _downloadService;
        private readonly IEventPublisher _eventPublisher;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly INopFileProvider _fileProvider;
        private readonly IProductAttributeParser _productAttributeParser;
        private readonly IRepository<Picture> _pictureRepository;
        private readonly IRepository<PictureBinary> _pictureBinaryRepository;
        private readonly IRepository<ProductPicture> _productPictureRepository;
        private readonly ISettingService _settingService;
        private readonly IUrlRecordService _urlRecordService;
        private readonly IWebHelper _webHelper;
        private readonly MediaSettings _mediaSettings;

        #endregion

        #region Ctor

        public PictureService(IDataProvider dataProvider,
            IDbContext dbContext,
            IDownloadService downloadService,
            IEventPublisher eventPublisher,
            IHttpContextAccessor httpContextAccessor,
            INopFileProvider fileProvider,
            IProductAttributeParser productAttributeParser,
            IRepository<Picture> pictureRepository,
            IRepository<PictureBinary> pictureBinaryRepository,
            IRepository<ProductPicture> productPictureRepository,
            ISettingService settingService,
            IUrlRecordService urlRecordService,
            IWebHelper webHelper,
            MediaSettings mediaSettings)
        {
            _dataProvider = dataProvider;
            _dbContext = dbContext;
            _downloadService = downloadService;
            _eventPublisher = eventPublisher;
            _httpContextAccessor = httpContextAccessor;
            _fileProvider = fileProvider;
            _productAttributeParser = productAttributeParser;
            _pictureRepository = pictureRepository;
            _pictureBinaryRepository = pictureBinaryRepository;
            _productPictureRepository = productPictureRepository;
            _settingService = settingService;
            _urlRecordService = urlRecordService;
            _webHelper = webHelper;
            _mediaSettings = mediaSettings;
        }

        #endregion

        #region Methods
        public bool StoreInDb { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void DeletePicture(Picture picture)
        {
            throw new NotImplementedException();
        }

        public string GetDefaultPictureUrl(int targetSize = 0, PictureType defaultPictureType = PictureType.Entity, string storeLocation = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 从mime类型返回文件扩展名。
        /// </summary>
        /// <param name="mimeType"></param>
        /// <returns></returns>
        public virtual string GetFileExtensionFromMimeType(string mimeType)
        {
            if (mimeType == null)
                return null;


            var parts = mimeType.Split('/');

            var lastPart = parts[parts.Length - 1];

            switch (lastPart)
            {
                case "pjpeg":
                    lastPart = "jpg";
                    break;

                case "x-png":
                    lastPart = "png";
                    break;

                case "x-icon":
                    lastPart = "ico";
                    break;
            }

            return lastPart;
        }

        /// <summary>
        /// 获取图片
        /// </summary>
        /// <param name="pictureId"></param>
        /// <returns></returns>
        public Picture GetPictureById(int pictureId)
        {
            if (pictureId == 0)
                return null;

            return _pictureRepository.GetById(pictureId);
        }

        public IPagedList<Picture> GetPictures(string virtualPath = "", int pageIndex = 0, int pageSize = int.MaxValue)
        {
            throw new NotImplementedException();
        }

        public IList<Picture> GetPicturesByProductId(int productId, int recordsToReturn = 0)
        {
            throw new NotImplementedException();
        }

        public string GetPictureSeName(string name)
        {
            throw new NotImplementedException();
        }

        public IDictionary<int, string> GetPicturesHash(int[] picturesIds)
        {
            throw new NotImplementedException();
        }

        public string GetPictureUrl(int pictureId, int targetSize = 0, bool showDefaultPicture = true, string storeLocation = null, PictureType defaultPictureType = PictureType.Entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取图片路径
        /// </summary>
        /// <param name="picture"></param>
        /// <param name="targetSize"></param>
        /// <param name="showDefaultPicture"></param>
        /// <param name="storeLocation"></param>
        /// <param name="defaultPictureType"></param>
        /// <returns></returns>
        public virtual string GetPictureUrl(Picture picture, int targetSize = 0, bool showDefaultPicture = true, string storeLocation = null, PictureType defaultPictureType = PictureType.Entity)
        {
            if (picture == null)
                return showDefaultPicture ? GetDefaultPictureUrl(targetSize, defaultPictureType, storeLocation) : string.Empty;

            byte[] pictureBinary = null;

            if (picture.IsNew)
            {
                DeletePictureThumbs(picture);

                pictureBinary = LoadPictureBinary(picture);
                if ((pictureBinary?.Length ?? 0) == 0)
                {
                    return showDefaultPicture?GetDefaultPictureUrl(targetSize, defaultPictureType, storeLocation) : string.Empty;
                }

                picture = UpdatePicture(picture.Id,
                   pictureBinary,
                   picture.MimeType,
                   picture.SeoFilename,
                   picture.AltAttribute,
                   picture.TitleAttribute,
                   false,
                   false);
            }

            var seoFileName = picture.SeoFilename;

            var lastPart = GetFileExtensionFromMimeType(picture.MimeType);

            string thumbFileName;

            if (targetSize == 0)
            {
                thumbFileName = !string.IsNullOrEmpty(seoFileName)
                    ? $"{picture.Id:0000000}_{seoFileName}.{lastPart}"
                    : $"{picture.Id:0000000}.{lastPart}";
            }
            else
            {
                thumbFileName = !string.IsNullOrEmpty(seoFileName)
                    ? $"{picture.Id:0000000}_{seoFileName}_{targetSize}.{lastPart}"
                    : $"{picture.Id:0000000}_{targetSize}.{lastPart}";
            }

            var thumbFilePath = GetThumbLocalPath(thumbFileName);


            using (var mutex = new Mutex(false, thumbFileName))
            {
                if (GeneratedThumbExists(thumbFilePath, thumbFileName))
                {
                    return GetThumbUrl(thumbFileName, storeLocation);
                }

                mutex.WaitOne();

                if (!GeneratedThumbExists(thumbFilePath, thumbFileName))
                {
                    pictureBinary = pictureBinary ?? LoadPictureBinary(picture);

                    if ((pictureBinary?.Length ?? 0) == 0)
                    {
                        return showDefaultPicture ? GetDefaultPictureUrl(targetSize, defaultPictureType, storeLocation) : string.Empty;
                    }

                    byte[] pictureBinaryResized;
                    if (targetSize > 0)
                    {
                        using (var image = Image.Load(pictureBinary, out var imageFormat))
                        {
                            image.Mutate(imageProcess => imageProcess.Resize(new ResizeOptions
                            {
                                Mode = ResizeMode.Max,
                                Size = CalculateDimensions(image.Size(), targetSize)
                            }));

                            pictureBinaryResized = EncodeImage(image, imageFormat);
                        }
                    }
                    else
                    {
                        pictureBinaryResized = pictureBinary.ToArray();

                    }
                    SaveThumb(thumbFilePath, thumbFileName, picture.MimeType, pictureBinaryResized);
                }
                mutex.ReleaseMutex();


            }
            return GetThumbUrl(thumbFileName, storeLocation);


        }

        public Picture GetProductPicture(Product product, string attributesXml)
        {
            throw new NotImplementedException();
        }

        public string GetThumbLocalPath(Picture picture, int targetSize = 0, bool showDefaultPicture = true)
        {
            throw new NotImplementedException();
        }

        public Picture InsertPicture(byte[] pictureBinary, string mimeType, string seoFilename, string altAttribute = null, string titleAttribute = null, bool isNew = true, bool validateBinary = true)
        {
            throw new NotImplementedException();
        }

        public Picture InsertPicture(IFormFile formFile, string defaultFileName = "", string virtualPath = "")
        {
            throw new NotImplementedException();
        }

        public byte[] LoadPictureBinary(Picture picture)
        {
            throw new NotImplementedException();
        }

        public Picture SetSeoFilename(int pictureId, string seoFilename)
        {
            throw new NotImplementedException();
        }

        public Picture UpdatePicture(int pictureId, byte[] pictureBinary, string mimeType, string seoFilename, string altAttribute = null, string titleAttribute = null, bool isNew = true, bool validateBinary = true)
        {
            throw new NotImplementedException();
        }

        public Picture UpdatePicture(Picture picture)
        {
            throw new NotImplementedException();
        }

        public byte[] ValidatePicture(byte[] pictureBinary, string mimeType)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Utilities

        /// <summary>
        /// 删除图片
        /// </summary>
        /// <param name="picture"></param>
        protected virtual void DeletePictureThumbs(Picture picture)
        {
            var filter = $"{picture.Id:0000000}*.*";

            var currentFiles = _fileProvider.GetFiles(_fileProvider.GetAbsolutePath(NopMediaDefaults.ImageThumbsPath), filter, false);

            foreach (var currentFileName in currentFiles)
            {
                var thumbFilePath = GetThumbLocalPath(currentFileName);
                _fileProvider.DeleteFile(thumbFilePath);
            }
        }

        /// <summary>
        /// 获取图片
        /// </summary>
        /// <param name="thumbFileName"></param>
        /// <returns></returns>
        protected virtual string GetThumbLocalPath(string thumbFileName)
        {
            var thumbsDirectoryPath = _fileProvider.GetAbsolutePath(NopMediaDefaults.ImageThumbsPath);

            if (_mediaSettings.MultipleThumbDirectories)
            {
                var fileNameWithoutExtension = _fileProvider.GetFileNameWithoutExtension(thumbFileName);

                if (fileNameWithoutExtension != null && fileNameWithoutExtension.Length > NopMediaDefaults.MultipleThumbDirectoriesLength)
                {
                    var subDirectoryName = fileNameWithoutExtension.Substring(0, NopMediaDefaults.MultipleThumbDirectoriesLength);
                    thumbsDirectoryPath = _fileProvider.GetAbsolutePath(NopMediaDefaults.ImageThumbsPath, subDirectoryName);
                    _fileProvider.CreateDirectory(thumbsDirectoryPath);
                }
            }

            var thumbFilePath = _fileProvider.Combine(thumbsDirectoryPath, thumbFileName);
            return thumbFilePath;
        }

        /// <summary>
        /// 指示某个文件是否已存在
        /// </summary>
        /// <param name="thumbFilePath"></param>
        /// <param name="thumbFileName"></param>
        /// <returns></returns>
        protected virtual bool GeneratedThumbExists(string thumbFilePath, string thumbFileName)
        {
            return _fileProvider.FileExists(thumbFilePath);
        }

        /// <summary>
        /// 获取图片URL
        /// </summary>
        /// <param name="thumbFileName"></param>
        /// <param name="storeLocation"></param>
        /// <returns></returns>
        protected virtual string GetThumbUrl(string thumbFileName, string storeLocation = null)
        {
            var url = GetImagesPathUrl(storeLocation) + "thumbs/";

            if (_mediaSettings.MultipleThumbDirectories)
            {
                var fileNameWithoutExtension = _fileProvider.GetFileNameWithoutExtension(thumbFileName);

                if (fileNameWithoutExtension != null && fileNameWithoutExtension.Length > NopMediaDefaults.MultipleThumbDirectoriesLength)
                {
                    var subDirectoryName = fileNameWithoutExtension.Substring(0, NopMediaDefaults.MultipleThumbDirectoriesLength);
                    url += subDirectoryName + "/";
                }
            }

            url += thumbFileName;

            return url;
        }

        /// <summary>
        /// 获取图片url
        /// </summary>
        /// <param name="storeLocation"></param>
        /// <returns></returns>
        protected virtual string GetImagesPathUrl(string storeLocation = null)
        {
            var pathBase = _httpContextAccessor.HttpContext.Request.PathBase.Value ?? string.Empty;

            var imagesPathUrl = _mediaSettings.UseAbsoluteImagePath ? storeLocation : $"{pathBase}/";

            imagesPathUrl = string.IsNullOrEmpty(imagesPathUrl) ? _webHelper.GetStoreLocation() : imagesPathUrl;

            imagesPathUrl += "images/";

            return imagesPathUrl;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="originalSize"></param>
        /// <param name="targetSize"></param>
        /// <param name="resizeType"></param>
        /// <param name="ensureSizePositive"></param>
        /// <returns></returns>
        protected virtual Size CalculateDimensions(Size originalSize, int targetSize,
            ResizeType resizeType = ResizeType.LongestSide, bool ensureSizePositive = true)
        {
            float width, height;

            switch (resizeType)
            {
                case ResizeType.LongestSide:
                    if (originalSize.Height > originalSize.Width)
                    {
                        width = originalSize.Width * (targetSize / (float)originalSize.Height);
                        height = targetSize;
                    }
                    else
                    {
                        width = targetSize;
                        height = originalSize.Height * (targetSize / (float)originalSize.Width);
                    }
                    break;

                case ResizeType.Width:
                    width = targetSize;
                    height = originalSize.Height * (targetSize / (float)originalSize.Width);
                    break;

                case ResizeType.Height:
                    width = originalSize.Width * (targetSize / (float)originalSize.Height);

                    height = targetSize;
                    break;

                default:
                    throw new Exception("Not supported ResizeType");

            }

            if (!ensureSizePositive)
                return new Size((int)Math.Round(width), (int)Math.Round(height));

            if (width < 1)
                width = 1;
            if (height < 1)
                height = 1;

            //we invoke Math.Round to ensure that no white background is rendered - https://www.nopcommerce.com/boards/t/40616/image-resizing-bug.aspx
            return new Size((int)Math.Round(width), (int)Math.Round(height));
        }

        /// <summary>
        /// 根据指定的图像格式将图像编码为字节数组
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="image"></param>
        /// <param name="imageFormat"></param>
        /// <param name="quality"></param>
        /// <returns></returns>
        protected virtual byte[] EncodeImage<T>(Image<T> image, IImageFormat imageFormat, int? quality = null) where T : struct, IPixel<T>
        {
            using (var stream = new MemoryStream())
            {
                var imageEncoder= SixLabors.ImageSharp.Configuration.Default.ImageFormatsManager.FindEncoder(imageFormat);

                switch (imageEncoder)
                {
                    case JpegEncoder jpegEncoder:
                        jpegEncoder.Subsample = JpegSubsample.Ratio444;
                        jpegEncoder.Quality = quality ?? _mediaSettings.DefaultImageQuality;
                        jpegEncoder.Encode(image, stream);
                        break;

                    case PngEncoder pngEncoder:
                        pngEncoder.ColorType = PngColorType.RgbWithAlpha;
                        pngEncoder.Encode(image, stream);
                        break;

                    case BmpEncoder bmpEncoder:
                        bmpEncoder.BitsPerPixel = BmpBitsPerPixel.Pixel32;
                        bmpEncoder.Encode(image, stream);
                        break;

                    case GifEncoder gifEncoder:
                        gifEncoder.Encode(image, stream);
                        break;

                    default:
                        imageEncoder.Encode(image, stream);
                        break;

                }
                return stream.ToArray();

            }
        }

        /// <summary>
        /// 保存一个值，指示某个文件是否已存在
        /// </summary>
        /// <param name="thumbFilePath"></param>
        /// <param name="thumbFileName"></param>
        /// <param name="mimeType"></param>
        /// <param name="binary"></param>
        protected virtual void SaveThumb(string thumbFilePath, string thumbFileName, string mimeType, byte[] binary)
        {
            var thumbsDirectoryPath = _fileProvider.GetAbsolutePath(NopMediaDefaults.ImageThumbsPath);
            _fileProvider.CreateDirectory(thumbsDirectoryPath);
            _fileProvider.WriteAllBytes(thumbFilePath, binary);

        }

        #endregion
    }
}
