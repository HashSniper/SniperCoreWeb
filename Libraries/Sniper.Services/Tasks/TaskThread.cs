using Microsoft.Extensions.DependencyInjection;
using Sniper.Core;
using Sniper.Core.Domain.Common;
using Sniper.Core.Domain.Tasks;
using Sniper.Core.Http;
using Sniper.Core.Infrastructure;
using Sniper.Services.Localization;
using Sniper.Services.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sniper.Services.Tasks
{
    public partial class TaskThread : IDisposable
    {
        #region Fileds
        private static readonly string _scheduleTaskUrl;
        private static readonly int? _timeout;
        private readonly Dictionary<string, string> _tasks;
        private Timer _timer;
        private bool _disposed;
        #endregion

        #region Ctor
        static TaskThread()
        {
            _scheduleTaskUrl = $"{EngineContext.Current.Resolve<IStoreContext>().CurrentStore.Url}{NopTaskDefaults.ScheduleTaskPath}";
            _timeout = EngineContext.Current.Resolve<CommonSettings>().ScheduleTaskRunTimeout;
        }

        internal TaskThread()
        {
            _tasks = new Dictionary<string, string>();

            Seconds = 10 * 60;
        }
        #endregion

        #region Properties

        public int Seconds { get; set; }

        public int InitSeconds { get; set; }

        public DateTime StartedUtc { get; private set; }

        public bool IsRunning { get; private set; }

        public int Interval
        {
            get
            {
                //if somebody entered more than "2147483" seconds, then an exception could be thrown (exceeds int.MaxValue)
                var interval = Seconds * 1000;
                if (interval <= 0)
                    interval = int.MaxValue;
                return interval;
            }
        }

        public int InitInterval
        {
            get
            {
                //if somebody entered less than "0" seconds, then an exception could be thrown
                var interval = InitSeconds * 1000;
                if (interval <= 0)
                    interval = 0;
                return interval;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the thread would be run only once (on application start)
        /// </summary>
        public bool RunOnlyOnce { get; set; }

        #endregion

        #region Methods
        public void Dispose()
        {
            if (_timer == null || _disposed)
                return;

            lock (this)
            {
                _timer.Dispose();
                _timer = null;
                _disposed = true;
            }
        }

        public void AddTask(ScheduleTask task)
        {
            if (!_tasks.ContainsKey(task.Name))
                _tasks[task.Name] = task.Type;
        }

        public void InitTimer()
        {
            if (_timer == null)
                _timer = new Timer(TimerHandler,null,InitInterval, Interval);
        }
        #endregion

        #region Utilities

        private void Run()
        {
            if (Seconds < 0)
                return;
            StartedUtc = DateTime.UtcNow;
            IsRunning = true;

            foreach (var taskName in _tasks.Keys)
            {
                var taskType = _tasks[taskName];
                try
                {
                    var client = EngineContext.Current.Resolve<IHttpClientFactory>().CreateClient(NopHttpDefaults.DefaultHttpClient);

                    if (_timeout.HasValue)
                    {
                        client.Timeout = TimeSpan.FromMilliseconds(_timeout.Value);

                        var data = new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>(nameof(taskType), taskType) });
                        client.PostAsync(_scheduleTaskUrl, data).Wait();
                    }
                }
                catch(Exception ex)
                {
                    var _serviceScopeFactory = EngineContext.Current.Resolve<IServiceScopeFactory>();
                    using (var scope = _serviceScopeFactory.CreateScope())
                    {
                        // Resolve
                        var logger = scope.ServiceProvider.GetRequiredService<ILogger>();
                        var localizationService = scope.ServiceProvider.GetRequiredService<ILocalizationService>();
                        var storeContext = scope.ServiceProvider.GetRequiredService<IStoreContext>();

                        var message = ex.InnerException?.GetType() == typeof(TaskCanceledException) ? localizationService.GetResource("ScheduleTasks.TimeoutError") : ex.Message;

                        message = string.Format(localizationService.GetResource("ScheduleTasks.Error"), taskName,
                            message, taskType, storeContext.CurrentStore.Name, _scheduleTaskUrl);

                        logger.Error(message, ex);
                    }
                }
            }
            IsRunning = true;
        }

        private void TimerHandler(object state)
        {
            try
            {
                _timer.Change(-1, -1);
                Run();

                if (RunOnlyOnce)
                    Dispose();
                else
                    _timer.Change(Interval, Interval);
            }
            catch
            {

            }
        }
        #endregion

    }
}
