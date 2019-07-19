using Sniper.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Orders
{
    /// <summary>
    /// 购物车设置
    /// </summary>
    public class ShoppingCartSettings : ISettings
    {
        /// <summary>
        /// 在将产品添加到购物车/心愿单后，是否应将客户重定向到购物车页面
        /// </summary>
        public bool DisplayCartAfterAddingProduct { get; set; }

        /// <summary>
        /// 在将产品添加到购物车/心愿单后，是否应将客户重定向到购物车页面
        /// </summary>
        public bool DisplayWishlistAfterAddingProduct { get; set; }

        /// <summary>
        /// 购物车中的最大商品数量
        /// </summary>
        public int MaximumShoppingCartItems { get; set; }

        /// <summary>
        /// 最大愿望清单
        /// </summary>
        public int MaximumWishlistItems { get; set; }

        /// <summary>
        /// 是否在迷你购物车块中显示产品图像
        /// </summary>
        public bool AllowOutOfStockItemsToBeAddedToWishlist { get; set; }

        /// <summary>
        /// 单击“添加到购物车”按钮时是否将项目从心愿单移动到购物车。 否则，他们被复制。
        /// </summary>
        public bool MoveItemsFromWishlistToCart { get; set; }

        /// <summary>
        /// 是否在商店之间共享购物车（和心愿单）（在多商店环境中）
        /// </summary>
        public bool CartsSharedBetweenStores { get; set; }

        /// <summary>
        /// 是否在购物车页面上显示产品图片
        /// </summary>
        public bool ShowProductImagesOnShoppingCart { get; set; }

        /// <summary>
        /// 是否在愿望清单中显示产品图片
        /// </summary>
        public bool ShowProductImagesOnWishList { get; set; }

        /// <summary>
        /// 是否在购物车页面上显示折扣框
        /// </summary>
        public bool ShowDiscountBox { get; set; }

        /// <summary>
        /// 是否在购物车页面上显示礼品卡盒
        /// </summary>
        public bool ShowGiftCardBox { get; set; }

        /// <summary>
        /// 购物车页面上的一些“交叉销售”
        /// </summary>
        public int CrossSellsNumber { get; set; }

        /// <summary>
        /// 是否启用“发送电子邮件心愿单”功能
        /// </summary>
        public bool EmailWishlistEnabled { get; set; }

        /// <summary>
        /// 是否为匿名用户启用“发送电子邮件心愿单”。
        /// </summary>
        public bool AllowAnonymousUsersToEmailWishlist { get; set; }

        /// <summary>
        /// 是否启用迷你购物车
        /// </summary>
        public bool MiniShoppingCartEnabled { get; set; }

        /// <summary>
        /// 是否在迷你购物车块中显示产品图像
        /// </summary>
        public bool ShowProductImagesInMiniShoppingCart { get; set; }

        /// <summary>
        /// 可以在迷你购物车块中显示的最大数量的产品
        /// </summary>
        public int MiniShoppingCartProductNumber { get; set; }

        /// <summary>
        /// 是否在计算期间舍入计算的价格和总计
        /// </summary>
        public bool RoundPricesDuringCalculation { get; set; }

        /// <summary>
        /// 当顾客购买更大量的特定产品时，店主是否能够提供特价。
        /// </summary>
        public bool GroupTierPricesForDistinctShoppingCartItems { get; set; }

        /// <summary>
        /// 客户是否能够在购物车中编辑产品
        /// </summary>
        public bool AllowCartItemEditing { get; set; }

        /// <summary>
        /// 客户是否会看到与产品关联的属性值的数量（当qty> 1时）
        /// </summary>
        public bool RenderAssociatedAttributeValueQuantity { get; set; }

    }
}
