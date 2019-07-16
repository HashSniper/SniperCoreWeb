using Sniper.Core;
using Sniper.Core.Domain.Customers;
using Sniper.Core.Domain.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Services.Logging
{
    public partial interface ICustomerActivityService
    {
        /// <summary>
        /// 插入活动日志类型项
        /// </summary>
        /// <param name="activityLogType"></param>
        void InsertActivityType(ActivityLogType activityLogType);

        /// <summary>
        /// 日志类型项
        /// </summary>
        /// <param name="activityLogType"></param>
        void UpdateActivityType(ActivityLogType activityLogType);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="activityLogType"></param>
        void DeleteActivityType(ActivityLogType activityLogType);

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        IList<ActivityLogType> GetAllActivityTypes();

        /// <summary>
        /// 获取单项
        /// </summary>
        /// <param name="activityLogTypeId"></param>
        /// <returns></returns>
        ActivityLogType GetActivityTypeById(int activityLogTypeId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="systemKeyword"></param>
        /// <param name="comment"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        ActivityLog InsertActivity(string systemKeyword, string comment, BaseEntity entity = null);

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="systemKeyword"></param>
        /// <param name="comment"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        ActivityLog InsertActivity(Customer customer, string systemKeyword, string comment, BaseEntity entity = null);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="activityLog"></param>
        void DeleteActivity(ActivityLog activityLog);

        /// <summary>
        /// 获取，分页
        /// </summary>
        /// <param name="createdOnFrom"></param>
        /// <param name="createdOnTo"></param>
        /// <param name="customerId"></param>
        /// <param name="activityLogTypeId"></param>
        /// <param name="ipAddress"></param>
        /// <param name="entityName"></param>
        /// <param name="entityId"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        IPagedList<ActivityLog> GetAllActivities(DateTime? createdOnFrom = null, DateTime? createdOnTo = null,
            int? customerId = null, int? activityLogTypeId = null, string ipAddress = null, string entityName = null, int? entityId = null,
            int pageIndex = 0, int pageSize = int.MaxValue);

        /// <summary>
        /// 获取一项
        /// </summary>
        /// <param name="activityLogId"></param>
        /// <returns></returns>
        ActivityLog GetActivityById(int activityLogId);

        /// <summary>
        /// 清除
        /// </summary>
        void ClearAllActivities();

    }
}
