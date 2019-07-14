using Sniper.Core.Domain.Tasks;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Services.Tasks
{
    public partial interface IScheduleTaskService
    {
        /// <summary>
        /// 删除线程
        /// </summary>
        /// <param name="task"></param>
        void DeleteTask(ScheduleTask task);

        /// <summary>
        /// 通过id获取线程
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        ScheduleTask GetTaskById(int taskId);

        /// <summary>
        /// 通过类型获取task
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        ScheduleTask GetTaskByType(string type);

        /// <summary>
        /// 获取线程列表
        /// </summary>
        /// <param name="showHidden"></param>
        /// <returns></returns>
        IList<ScheduleTask> GetAllTasks(bool showHidden = false);

        /// <summary>
        /// 插入线程
        /// </summary>
        /// <param name="task"></param>
        void InsertTask(ScheduleTask task);

        /// <summary>
        /// 更新线程
        /// </summary>
        /// <param name="task"></param>
        void UpdateTask(ScheduleTask task);

    }
}
