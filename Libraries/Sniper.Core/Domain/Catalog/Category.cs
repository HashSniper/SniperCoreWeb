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
    public partial class Category : BaseEntity, ILocalizedEntity, ISlugSupported, IAclSupported, IStoreMappingSupported, IDiscountSupported
    {
        private ICollection<DiscountCategoryMapping> _discountCategoryMappings;

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 使用的类别模板标识符的值
        /// </summary>
        public int CategoryTemplateId { get; set; }

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
        /// 父类id
        /// </summary>
        public int ParentCategoryId { get; set; }

        /// <summary>
        /// 图片id
        /// </summary>
        public int PictureId { get; set; }

        /// <summary>
        /// 页面大小
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 指示客户是否可以选择页面大小的值
        /// </summary>
        public bool AllowCustomersToSelectPageSize { get; set; }

        /// <summary>
        /// 可用的客户可选页面大小选项
        /// </summary>
        public string PageSizeOptions { get; set; }

        /// <summary>
        /// 价格区间
        /// </summary>
        public string PriceRanges { get; set; }

        /// <summary>
        /// 是否在主页上显示该类别
        /// </summary>
        public bool ShowOnHomepage { get; set; }

        /// <summary>
        /// 指示是否在顶部菜单中包含此类别的值
        /// </summary>
        public bool IncludeInTopMenu { get; set; }

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
        /// 指示实体是否已被删除
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

        /// <summary>
        /// 应用折扣的集合
        /// </summary>
        public virtual IList<Discount> AppliedDiscounts => DiscountCategoryMappings.Select(mapping => mapping.Discount).ToList();



        /// <summary>
        /// 折扣类别映射
        /// </summary>
        public virtual ICollection<DiscountCategoryMapping> DiscountCategoryMappings
        {
            get => _discountCategoryMappings ?? (_discountCategoryMappings = new List<DiscountCategoryMapping>());
            set => _discountCategoryMappings = value;
        }
    }
}
