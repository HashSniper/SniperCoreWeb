using System;
using System.Collections.Generic;
using System.Linq;
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

        public virtual Log InsertLog(LogLevel logLevel, string shortMessage, string fullMessage = "", Customer customer = null)
        {
            if (IgnoreLog(shortMessage) || IgnoreLog(fullMessage))
                return null;

            var log = new Log
            {
                LogLevel = logLevel,
                ShortMessage = shortMessage,
                FullMessage = fullMessage,
                IpAddress = _webHelper.GetCurrentIpAddress(),
                Customer = customer,
                PageUrl = _webHelper.GetThisPageUrl(true),
                ReferrerUrl=_webHelper.GetUrlReferrer(),
                CreatedOnUtc=DateTime.UtcNow
            };

            _logRepository.Insert(log);
            return log;
        }
        /// <summary>
        /// 确定是否启用了日志级别
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public bool IsEnabled(LogLevel level)
        {
            switch (level)
            {
                case LogLevel.Debug:
                    return false;
                default:
                    return true;
            }
        }

        public void Warning(string message, Exception exception = null, Customer customer = null)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Utilities

        /// <summary>
        /// 判断是否需要记录
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        protected virtual bool IgnoreLog(string message)
        {
            if (!_commonSettings.IgnoreLogWordlist.Any())
            {
                return false;
            }

            if (string.IsNullOrEmpty(message))
                return false;

            return _commonSettings.IgnoreLogWordlist.Any(s => message.IndexOf(s, StringComparison.InvariantCultureIgnoreCase) >= 0);
        }

        #endregion
    }
}
