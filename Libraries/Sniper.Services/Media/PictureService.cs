using System;
using System.Collections.Generic;
using System.Text;
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

        public string GetFileExtensionFromMimeType(string mimeType)
        {
            throw new NotImplementedException();
        }

        public Picture GetPictureById(int pictureId)
        {
            throw new NotImplementedException();
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

        public string GetPictureUrl(Picture picture, int targetSize = 0, bool showDefaultPicture = true, string storeLocation = null, PictureType defaultPictureType = PictureType.Entity)
        {
            throw new NotImplementedException();
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
    }
}
