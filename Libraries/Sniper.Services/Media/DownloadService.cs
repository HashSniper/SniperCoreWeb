using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Sniper.Core.Data;
using Sniper.Core.Domain.Media;
using Sniper.Core.Domain.Orders;
using Sniper.Services.Events;

namespace Sniper.Services.Media
{
    public partial class DownloadService : IDownloadService
    {
        #region Fields

        private readonly IEventPublisher _eventPubisher;
        private readonly IRepository<Download> _downloadRepository;

        #endregion

        #region Ctor

        public DownloadService(IEventPublisher eventPubisher,
            IRepository<Download> downloadRepository)
        {
            _eventPubisher = eventPubisher;
            _downloadRepository = downloadRepository;
        }

        #endregion

        #region Methods
        public void DeleteDownload(Download download)
        {
            throw new NotImplementedException();
        }

        public byte[] GetDownloadBits(IFormFile file)
        {
            throw new NotImplementedException();
        }

        public Download GetDownloadByGuid(Guid downloadGuid)
        {
            throw new NotImplementedException();
        }

        public Download GetDownloadById(int downloadId)
        {
            throw new NotImplementedException();
        }

        public void InsertDownload(Download download)
        {
            throw new NotImplementedException();
        }

        public bool IsDownloadAllowed(OrderItem orderItem)
        {
            throw new NotImplementedException();
        }

        public bool IsLicenseDownloadAllowed(OrderItem orderItem)
        {
            throw new NotImplementedException();
        }

        public void UpdateDownload(Download download)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
