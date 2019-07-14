using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sniper.Core.Data;
using Sniper.Core.Domain.Tasks;

namespace Sniper.Services.Tasks
{
    public partial class ScheduleTaskService : IScheduleTaskService
    {
        #region Fileds
        private readonly IRepository<ScheduleTask> _taskRepository;
        #endregion

        #region Ctor

        public ScheduleTaskService(IRepository<ScheduleTask> taskRepository)
        {
            _taskRepository = taskRepository;
        }

        #endregion

        #region Methods
        public void DeleteTask(ScheduleTask task)
        {
            throw new NotImplementedException();
        }

        public virtual IList<ScheduleTask> GetAllTasks(bool showHidden = false)
        {
            var query = _taskRepository.Table;
            if (!showHidden)
            {
                query = query.Where(t => t.Enabled);
            }

            query = query.OrderByDescending(t => t.Seconds);
            return query.ToList();
        }

        public ScheduleTask GetTaskById(int taskId)
        {
            throw new NotImplementedException();
        }

        public ScheduleTask GetTaskByType(string type)
        {
            throw new NotImplementedException();
        }

        public void InsertTask(ScheduleTask task)
        {
            throw new NotImplementedException();
        }

        public void UpdateTask(ScheduleTask task)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
