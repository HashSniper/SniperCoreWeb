using Sniper.Core.Infrastructure;
using Sniper.Services.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Services.Directory
{
    public partial class GeoLookupService : IGeoLookupService
    {
        #region Fields

        private readonly ILogger _logger;
        private readonly INopFileProvider _fileProvider;

        #endregion

        #region Ctor

        public GeoLookupService(ILogger logger,
            INopFileProvider fileProvider)
        {
            _logger = logger;
            _fileProvider = fileProvider;
        }

        #endregion

        #region Methods
        public string LookupCountryIsoCode(string ipAddress)
        {
            throw new NotImplementedException();
        }

        public string LookupCountryName(string ipAddress)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
