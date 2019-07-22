using Microsoft.AspNetCore.Http;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Sniper.Core;
using Sniper.Core.Caching;
using Sniper.Core.Configuration;
using Sniper.Core.Data;
using Sniper.Core.Domain.Catalog;
using Sniper.Core.Domain.Media;
using Sniper.Core.Infrastructure;
using Sniper.Data;
using Sniper.Services.Catalog;
using Sniper.Services.Configuration;
using Sniper.Services.Events;
using Sniper.Services.Seo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Services.Media
{
    public partial class AzurePictureService : PictureService
    {
        #region Fields

        private static bool _azureBlobStorageAppendContainerName;
        private static bool _isInitialized;
        private static CloudBlobContainer _container;
        private static string _azureBlobStorageConnectionString;
        private static string _azureBlobStorageContainerName;
        private static string _azureBlobStorageEndPoint;

        private readonly IStaticCacheManager _cacheManager;
        private readonly MediaSettings _mediaSettings;
        private readonly object _locker = new object();

        #endregion

        #region Ctor

        public AzurePictureService(IDataProvider dataProvider,
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
            IStaticCacheManager cacheManager,
            IUrlRecordService urlRecordService,
            IWebHelper webHelper,
            MediaSettings mediaSettings,
            NopConfig config)
            : base(dataProvider,
                  dbContext,
                  downloadService,
                  eventPublisher,
                  httpContextAccessor,
                  fileProvider,
                  productAttributeParser,
                  pictureRepository,
                  pictureBinaryRepository,
                  productPictureRepository,
                  settingService,
                  urlRecordService,
                  webHelper,
                  mediaSettings)
        {
            _cacheManager = cacheManager;
            _mediaSettings = mediaSettings;

            OneTimeInit(config);
        }

        #endregion

        #region Utilities
        protected void OneTimeInit(NopConfig config)
        {
            if (_isInitialized)
                return;
            if (string.IsNullOrEmpty(config.AzureBlobStorageConnectionString))
                throw new Exception("Azure connection string for BLOB is not specified");

            if (string.IsNullOrEmpty(config.AzureBlobStorageContainerName))
                throw new Exception("Azure container name for BLOB is not specified");

            if (string.IsNullOrEmpty(config.AzureBlobStorageEndPoint))
                throw new Exception("Azure end point for BLOB is not specified");

            lock (_locker)
            {
                if (_isInitialized)
                    return;

                _azureBlobStorageAppendContainerName = config.AzureBlobStorageAppendContainerName;
                _azureBlobStorageConnectionString = config.AzureBlobStorageConnectionString;
                _azureBlobStorageContainerName = config.AzureBlobStorageContainerName.Trim().ToLower();
                _azureBlobStorageEndPoint = config.AzureBlobStorageEndPoint.Trim().ToLower().TrimEnd('/');

                CreateCloudBlobContainer();

                _isInitialized = true;
            }
        }

        protected virtual async void CreateCloudBlobContainer()
        {
            var storageAccount = CloudStorageAccount.Parse(_azureBlobStorageConnectionString);
            if (storageAccount == null)
                throw new Exception("Azure connection string for BLOB is not working");

            //should we do it for each HTTP request?
            var blobClient = storageAccount.CreateCloudBlobClient();

            //GetContainerReference doesn't need to be async since it doesn't contact the server yet
            _container = blobClient.GetContainerReference(_azureBlobStorageContainerName);

            await _container.CreateIfNotExistsAsync();
            await _container.SetPermissionsAsync(new BlobContainerPermissions
            {
                PublicAccess = BlobContainerPublicAccessType.Blob
            });
        }

        #endregion
    }
}
