using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Catalog
{
    public partial class ProductAttributeCombination : BaseEntity
    {
        /// <summary>
        /// 产品标识符
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 属性xml
        /// </summary>
        public string AttributesXml { get; set; }

        /// <summary>
        /// 库存数量
        /// </summary>
        public int StockQuantity { get; set; }

        /// <summary>
        /// 是否在缺货时允许订单
        /// </summary>
        public bool AllowOutOfStockOrders { get; set; }

        /// <summary>
        /// the SKU
        /// </summary>
        public string Sku { get; set; }

        /// <summary>
        /// 制造商部件号
        /// </summary>
        public string ManufacturerPartNumber { get; set; }

        /// <summary>
        /// 全球贸易项目编号（GTIN）。 这些标识符包括UPC（在北美），EAN（在欧洲），JAN（在日本）和ISBN（用于书籍）。
        /// </summary>
        public string Gtin { get; set; }

        /// <summary>
        /// 属性组合价格。 这样，当将此属性组合添加到购物车时，商店所有者可以覆盖默认产品价格。 例如，您可以通过这种方式给予折扣。
        /// </summary>
        public decimal? OverriddenPrice { get; set; }

        /// <summary>
        /// 应通知管理员的数量
        /// </summary>
        public int NotifyAdminForQuantityBelow { get; set; }

        /// <summary>
        /// 图片标识符
        /// </summary>
        public int PictureId { get; set; }

        /// <summary>
        /// 铲平
        /// </summary>
        public virtual Product Product { get; set; }

    }
}
