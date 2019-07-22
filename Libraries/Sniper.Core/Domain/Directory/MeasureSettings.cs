using Sniper.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Directory
{
    public class MeasureSettings : ISettings
    {
        /// <summary>
        /// Base dimension identifier
        /// </summary>
        public int BaseDimensionId { get; set; }

        /// <summary>
        /// Base weight identifier
        /// </summary>
        public int BaseWeightId { get; set; }
    }
}
