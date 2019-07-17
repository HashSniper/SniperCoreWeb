using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Directory
{
    public partial class ExchangeRate
    {
        public ExchangeRate()
        {
            CurrencyCode = string.Empty;
            Rate = 1.0m;
        }

        /// <summary>
        /// 汇率的三字母ISO代码，例如 美元
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// 货币的转换率
        /// </summary>
        public decimal Rate { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdatedOn { get; set; }

        public override string ToString()
        {
            return $"{CurrencyCode} {Rate}";
        }
    }
}
