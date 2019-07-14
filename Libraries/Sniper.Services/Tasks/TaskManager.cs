using Sniper.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Sniper.Services.Tasks
{
    public partial class TaskManager
    {
        #region Fileds
        private readonly List<TaskThread> _taskThreads = new List<TaskThread>();


        #endregion

        #region Ctor
        private TaskManager()
        {

        }
        #endregion

        #region Properties
        public static TaskManager Instance { get; } = new TaskManager();

        public IList<TaskThread> TaskThreads => new ReadOnlyCollection<TaskThread>(_taskThreads);
        #endregion

        #region Methods
        /// <summary>
        /// 初始化处理
        /// </summary>
        public void Initialize()
        {
            _taskThreads.Clear();

            var taskService = EngineContext.Current.Resolve<IScheduleTaskService>();

            var scheduleTasks = taskService.GetAllTasks().OrderBy(x => x.Seconds).ToList();

            foreach (var scheduleTask in scheduleTasks)
            {
                var taskThread = new TaskThread()
                {
                    Seconds = scheduleTask.Seconds
                };

                if (scheduleTask.LastStartUtc.HasValue)
                {
                    var secondsLeft = (DateTime.UtcNow - scheduleTask.LastStartUtc).Value.TotalSeconds;

                    if (secondsLeft >= scheduleTask.Seconds)
                    {
                        taskThread.InitSeconds = 0;
                    }
                    else
                    {
                        taskThread.InitSeconds = (int)(scheduleTask.Seconds - secondsLeft) + 1;
                    }
                }
                else
                {
                    taskThread.InitSeconds = scheduleTask.Seconds;
                }

                taskThread.AddTask(scheduleTask);
                _taskThreads.Add(taskThread);
            }
        }

        public void Start()
        {
            foreach (var taskThread in _taskThreads)
            {
                taskThread.InitTimer();
            }
        }
        #endregion
    }
}
