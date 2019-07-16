using Sniper.Core.Domain.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Directory
{
    public partial class StateProvince : BaseEntity, ILocalizedEntity
    {
        /// <summary>
        /// 国家编号
        /// </summary>
        public int CountryId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 缩写
        /// </summary>
        public string Abbreviation { get; set; }

        /// <summary>
        /// 该实体是否已发布
        /// </summary>
        public bool Published { get; set; }

        /// <summary>
        /// 展示编号
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 国家
        /// </summary>
        public virtual Country Country { get; set; }

    }
}
