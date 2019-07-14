using System;
using System.Collections.Generic;
using System.Text;
using Sniper.Core;
using Sniper.Core.Data;
using Sniper.Core.Domain.Common;
using Sniper.Core.Domain.Customers;
using Sniper.Core.Domain.Logging;
using Sniper.Data;

namespace Sniper.Services.Logging
{
    public partial class DefaultLogger : ILogger
    {
        #region Fileds
        private readonly CommonSettings _commonSettings;

        private readonly IDbContext _dbContext;

        private readonly IRepository<Log> _logRepository;
        private readonly IWebHelper _webHelper;

        #endregion

        #region Ctor
        public DefaultLogger(CommonSettings commonSettings, IDbContext dbContext, IRepository<Log> logRepository, IWebHelper webHelper)
        {
            _commonSettings = commonSettings;
            _dbContext = dbContext;
            _logRepository = logRepository;
            _webHelper = webHelper;
        }
        #endregion

        #region
        public void ClearLog()
        {
            throw new NotImplementedException();
        }

        public void DeleteLog(Log log)
        {
            throw new NotImplementedException();
        }

        public void DeleteLogs(IList<Log> logs)
        {
            throw new NotImplementedException();
        }

        public void Error(string message, Exception exception = null, Customer customer = null)
        {
            throw new NotImplementedException();
        }

        public IPagedList<Log> GetAllLogs(DateTime? fromUtc = null, DateTime? toUtc = null, string message = "", LogLevel? logvel = null, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            throw new NotImplementedException();
        }

        public Log GetLogById(int logId)
        {
            throw new NotImplementedException();
        }

        public IList<Log> GetLogByIds(List<int> logIds)
        {
            throw new NotImplementedException();
        }

        public virtual void Information(string message, Exception exception = null, Customer customer = null) 

        {
            if (exception is System.Threading.ThreadAbortException)
                return;
            if (IsEnabled(LogLevel.Information))
                InsertLog(LogLevel.Information, message, exception?.ToString() ?? string.Empty, customer);
        }

        public Log InsertLog(LogLevel logLevel, string shortMessage, string fullMessage = "", Customer customer = null)
        {
            throw new NotImplementedException();
        }

        public bool IsEnabled(LogLevel level)
        {
            throw new NotImplementedException();
        }

        public void Warning(string message, Exception exception = null, Customer customer = null)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
