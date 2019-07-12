using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Data
{
    public partial class DataSettings
    {
        #region Ctor
        public DataSettings()
        {
            RawDataSettings = new Dictionary<string, string>();
        }
        #endregion

        #region Properties

        [JsonConverter(typeof(StringEnumConverter))]
        public DataProviderType DataProvider { get; set; }

        public string DataConnectionString{ get; set; }

        public IDictionary<string, string> RawDataSettings { get; }

        [JsonIgnore]
        public bool IsValid => DataProvider != DataProviderType.Unknown && !string.IsNullOrEmpty(DataConnectionString);

        #endregion
    }
}
