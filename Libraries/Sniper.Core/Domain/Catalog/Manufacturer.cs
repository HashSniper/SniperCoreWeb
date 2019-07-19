using Sniper.Core.Domain.Discounts;
using Sniper.Core.Domain.Localization;
using Sniper.Core.Domain.Security;
using Sniper.Core.Domain.Seo;
using Sniper.Core.Domain.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sniper.Core.Domain.Catalog
{
    /// <summary>
    /// 制造商
    /// </summary>
    public partial class Manufacturer : BaseEntity, ILocalizedEntity, ISlugSupported, IAclSupported, IStoreMappingSupported, IDiscountSupported
    {
        private ICollection<DiscountManufacturerMapping> _discountManufacturerMappings;

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 制造商模板标识
        /// </summary>
        public int ManufacturerTemplateId { get; set; }

        /// <summary>
        /// 元关键字
        /// </summary>
        public string MetaKeywords { get; set; }
        
        /// <summary>
        /// 元描述
        /// </summary>
        public string MetaDescription { get; set; }

        /// <summary>
        /// title
        /// </summary>
        public string MetaTitle { get; set; }

        /// <summary>
        /// 图片id
        /// </summary>
        public int PictureId { get; set; }

        /// <summary>
        /// 页面大小
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 客户是否可以选择页面大小
        /// </summary>
        public bool AllowCustomersToSelectPageSize { get; set; }

        /// <summary>
        /// 页面大小选项
        /// </summary>
        public string PageSizeOptions { get; set; }

        /// <summary>
        /// 价格区间
        /// </summary>
        public string PriceRanges { get; set; }

        /// <summary>
        /// 实体是否受ACL限制
        /// </summary>
        public bool SubjectToAcl { get; set; }

        /// <summary>
        /// 该实体是否受限于某些商店
        /// </summary>
        public bool LimitedToStores { get; set; }

        /// <summary>
        /// 该实体是否已发布
        /// </summary>
        public bool Published { get; set; }

        /// <summary>
        /// 是否已经删除
        /// </summary>
        public bool Deleted { get; set; }

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

        public IList<Discount> AppliedDiscounts => DiscountManufacturerMappings.Select(mapping => mapping.Discount).ToList();

        public virtual ICollection<DiscountManufacturerMapping> DiscountManufacturerMappings
        {
            get => _discountManufacturerMappings ?? (_discountManufacturerMappings = new List<DiscountManufacturerMapping>());
            set => _discountManufacturerMappings = value;
        }

    }
}
