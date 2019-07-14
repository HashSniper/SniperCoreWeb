using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Tasks
{
    public partial class ScheduleTask:BaseEntity
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 运行周期，以秒为单位
        /// </summary>
        public int Seconds { get; set; }

        /// <summary>
        /// 设置适当的IScheduleTask类的类型
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// task是否启用
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// 当出现错误是否停止
        /// </summary>
        public bool StopOnError { get; set; }

        /// <summary>
        /// 上次运行开始时间
        /// </summary>
        public DateTime? LastStartUtc { get; set; }

        /// <summary>
        /// 上次运行停止时间
        /// </summary>
        public DateTime? LastEndUtc { get; set; }

        /// <summary>
        /// 上次运行成功时间
        /// </summary>
        public DateTime? LastSuccessUtc { get; set; }


    }
}
