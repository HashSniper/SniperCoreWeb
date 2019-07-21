using Sniper.Core.Domain.Localization;
using Sniper.Core.Domain.Stores;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Directory
{
    /// <summary>
    /// 货币
    /// </summary>
    public partial class Currency : BaseEntity, ILocalizedEntity, IStoreMappingSupported
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// 费用
        /// </summary>
        public decimal Rate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string DisplayLocale { get; set; }

        /// <summary>
        /// 格式
        /// </summary>
        public string CustomFormatting { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool LimitedToStores { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool Published { get; set; }

        /// <summary>
        /// 展示顺序
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdatedOnUtc { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int RoundingTypeId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public RoundingType RoundingType
        {
            get => (RoundingType)RoundingTypeId;
            set => RoundingTypeId=(int)value;
        }

    }
}
