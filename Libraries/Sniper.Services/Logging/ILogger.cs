using Sniper.Core;
using Sniper.Core.Domain.Customers;
using Sniper.Core.Domain.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Services.Logging
{
    public partial interface ILogger
    {
        /// <summary>
        /// 确定是否启用日志级别
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        bool IsEnabled(LogLevel level);

        /// <summary>
        /// 删除日志
        /// </summary>
        /// <param name="log"></param>
        void DeleteLog(Log log);
        /// <summary>
        /// 删除日志
        /// </summary>
        /// <param name="logs"></param>
        void DeleteLogs(IList<Log> logs);

        /// <summary>
        /// 清空日志
        /// </summary>
        void ClearLog();

        /// <summary>
        /// 获取日志记录
        /// </summary>
        /// <param name="fromUtc"></param>
        /// <param name="toUtc"></param>
        /// <param name="message"></param>
        /// <param name="logvel"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        IPagedList<Log> GetAllLogs(DateTime? fromUtc = null, DateTime? toUtc = null, string message = "", LogLevel? logvel = null, int pageIndex = 0, int pageSize = int.MaxValue);

        /// <summary>
        /// 通过id获取日志
        /// </summary>
        /// <param name="logId"></param>
        /// <returns></returns>
        Log GetLogById(int logId);

        /// <summary>
        /// 通过id获取日志列表
        /// </summary>
        /// <param name="logIds"></param>
        /// <returns></returns>
        IList<Log> GetLogByIds(List<int> logIds);

        /// <summary>
        /// 插入日志
        /// </summary>
        /// <param name="logLevel"></param>
        /// <param name="shortMessage"></param>
        /// <param name="fullMessage"></param>
        /// <param name="customer"></param>
        /// <returns></returns>
        Log InsertLog(LogLevel logLevel, string shortMessage, string fullMessage = "", Customer customer = null);

        /// <summary>
        /// 信息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        /// <param name="customer"></param>
        void Information(string message, Exception exception = null, Customer customer = null);

        /// <summary>
        /// 警告
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        /// <param name="customer"></param>
        void Warning(string message, Exception exception = null, Customer customer = null);

        /// <summary>
        /// 错误
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        /// <param name="customer"></param>
        void Error(string message, Exception exception = null, Customer customer = null);
    }
}
