using Sniper.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Catalog
{
    public class CatalogSettings : ISettings
    {
        public CatalogSettings()
        {
            ProductSortingEnumDisabled = new List<int>();
            ProductSortingEnumDisplayOrder = new Dictionary<int, int>();
        }

        /// <summary>
        /// 未公开的产品详细信息页面的详细信息页面可以打开（用于SEO优化）
        /// </summary>
        public bool AllowViewUnpublishedProductPage { get; set; }

        /// <summary>
        /// 表示客户在访问未发布产品的详细信息页面时应看到“已停止”消息（如果“AllowViewUnpublishedProductPage”为“true”）
        /// </summary>
        public bool DisplayDiscontinuedMessageForUnpublishedProducts { get; set; }

        /// <summary>
        /// 该值指示在订单取消（删除）后是否应更新“已发布”或“禁用购买/心愿单按钮”标志。
        /// </summary>
        public bool PublishBackProductWhenCancellingOrders { get; set; }

        /// <summary>
        /// 是否在产品详细信息页面上显示产品SKU
        /// </summary>
        public bool ShowSkuOnProductDetailsPage { get; set; }

        /// <summary>
        /// 是否在目录页面上显示产品SKU
        /// </summary>
        public bool ShowSkuOnCatalogPages { get; set; }

        /// <summary>
        /// 是否显示产品的制造商部件号
        /// </summary>
        public bool ShowManufacturerPartNumber { get; set; }

        /// <summary>
        /// 是否显示产品的GTIN
        /// </summary>
        public bool ShowGtin { get; set; }

        /// <summary>
        /// 指示是否应为产品显示“免运费”图标
        /// </summary>
        public bool ShowFreeShippingNotification { get; set; }

        /// <summary>
        /// 是否启用了产品排序
        /// </summary>
        public bool AllowProductSorting { get; set; }

        /// <summary>
        /// 指示是否允许客户更改产品视图模式
        /// </summary>
        public bool AllowProductViewModeChanging { get; set; }

        /// <summary>
        /// 默认视图模式
        /// </summary>
        public string DefaultViewMode { get; set; }

        /// <summary>
        /// 类别详细信息页面是否应包含子类别的产品
        /// </summary>
        public bool ShowProductsFromSubcategories { get; set; }

        /// <summary>
        /// 在每个类别旁边显示产品数量
        /// </summary>
        public bool ShowCategoryProductNumber { get; set; }

        /// <summary>
        ///包括子类别（当'ShowCategoryProductNumber'为'true'时）
        /// </summary>
        public bool ShowCategoryProductNumberIncludingSubcategories { get; set; }

        /// <summary>
        /// 是否启用了类别痕迹导览
        /// </summary>
        public bool CategoryBreadcrumbEnabled { get; set; }

        /// <summary>
        /// 指示是否启用“分享按钮”
        /// </summary>
        public bool ShowShareButton { get; set; }

        /// <summary>
        /// 页面分享
        /// </summary>
        public string PageShareCode { get; set; }

        /// <summary>
        /// 产品评论必须获得批准
        /// </summary>
        public bool ProductReviewsMustBeApproved { get; set; }

        /// <summary>
        /// 产品评论的默认评级值
        /// </summary>
        public int DefaultProductRatingValue { get; set; }

        /// <summary>
        /// 指示是否允许匿名用户编写产品评论。
        /// </summary>
        public bool AllowAnonymousUsersToReviewProduct { get; set; }

        /// <summary>
        /// 是否只能由已订购产品的客户审核产品
        /// </summary>
        public bool ProductReviewPossibleOnlyAfterPurchasing { get; set; }

        /// <summary>
        /// 是否启用了商店所有者关于新产品评论的通知
        /// </summary>
        public bool NotifyStoreOwnerAboutNewProductReviews { get; set; }

        /// <summary>
        /// 是否启用了有关产品评论回复的客户通知
        /// </summary>
        public bool NotifyCustomerAboutProductReviewReply { get; set; }

        /// <summary>
        /// 是否将按商店过滤产品评论
        /// </summary>
        public bool ShowProductReviewsPerStore { get; set; }

        /// <summary>
        /// 在帐户页面上显示产品评论标签
        /// </summary>
        public bool ShowProductReviewsTabOnAccountPage { get; set; }

        /// <summary>
        /// 帐户页面中产品评论的页面大小
        /// </summary>
        public int ProductReviewsPageSizeOnAccountPage { get; set; }

        /// <summary>
        /// 产品评论是否应按创建日期按升序排序的值
        /// </summary>
        public bool ProductReviewsSortByCreatedDateAscending { get; set; }

        /// <summary>
        /// 是否已启用产品“向朋友发送电子邮件”功能
        /// </summary>
        public bool EmailAFriendEnabled { get; set; }

        /// <summary>
        /// 是否允许匿名用户通过电子邮件发送给朋友。
        /// </summary>
        public bool AllowAnonymousUsersToEmailAFriend { get; set; }

        /// <summary>
        /// 一些“最近浏览过的产品”
        /// </summary>
        public int RecentlyViewedProductsNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether "Recently viewed products" feature is enabled
        /// </summary>
        public bool RecentlyViewedProductsEnabled { get; set; }

        /// <summary>
        /// Gets or sets a number of products on the "New products" page
        /// </summary>
        public int NewProductsNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether "New products" page is enabled
        /// </summary>
        public bool NewProductsEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether "Compare products" feature is enabled
        /// </summary>
        public bool CompareProductsEnabled { get; set; }

        /// <summary>
        /// Gets or sets an allowed number of products to be compared
        /// </summary>
        public int CompareProductsNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether autocomplete is enabled
        /// </summary>
        public bool ProductSearchAutoCompleteEnabled { get; set; }

        /// <summary>
        /// Gets or sets a number of products to return when using "autocomplete" feature
        /// </summary>
        public int ProductSearchAutoCompleteNumberOfProducts { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to show product images in the auto complete search
        /// </summary>
        public bool ShowProductImagesInSearchAutoComplete { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to show link to all result in the auto complete search
        /// </summary>
        public bool ShowLinkToAllResultInSearchAutoComplete { get; set; }

        /// <summary>
        /// Gets or sets a minimum search term length
        /// </summary>
        public int ProductSearchTermMinimumLength { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to show bestsellers on home page
        /// </summary>
        public bool ShowBestsellersOnHomepage { get; set; }

        /// <summary>
        /// Gets or sets a number of bestsellers on home page
        /// </summary>
        public int NumberOfBestsellersOnHomepage { get; set; }

        /// <summary>
        /// Gets or sets a number of products per page on the search products page
        /// </summary>
        public int SearchPageProductsPerPage { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether customers are allowed to select page size on the search products page
        /// </summary>
        public bool SearchPageAllowCustomersToSelectPageSize { get; set; }

        /// <summary>
        /// Gets or sets the available customer selectable page size options on the search products page
        /// </summary>
        public string SearchPagePageSizeOptions { get; set; }

        /// <summary>
        /// Gets or sets "List of products purchased by other customers who purchased the above" option is enable
        /// </summary>
        public bool ProductsAlsoPurchasedEnabled { get; set; }

        /// <summary>
        /// Gets or sets a number of products also purchased by other customers to display
        /// </summary>
        public int ProductsAlsoPurchasedNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether we should process attribute change using AJAX. It's used for dynamical attribute change, SKU/GTIN update of combinations, conditional attributes
        /// </summary>
        public bool AjaxProcessAttributeChange { get; set; }

        /// <summary>
        /// Gets or sets a number of product tags that appear in the tag cloud
        /// </summary>
        public int NumberOfProductTags { get; set; }

        /// <summary>
        /// Gets or sets a number of products per page on 'products by tag' page
        /// </summary>
        public int ProductsByTagPageSize { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether customers can select the page size for 'products by tag'
        /// </summary>
        public bool ProductsByTagAllowCustomersToSelectPageSize { get; set; }

        /// <summary>
        /// Gets or sets the available customer selectable page size options for 'products by tag'
        /// </summary>
        public string ProductsByTagPageSizeOptions { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to include "Short description" in compare products
        /// </summary>
        public bool IncludeShortDescriptionInCompareProducts { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to include "Full description" in compare products
        /// </summary>
        public bool IncludeFullDescriptionInCompareProducts { get; set; }

        /// <summary>
        /// An option indicating whether products on category and manufacturer pages should include featured products as well
        /// </summary>
        public bool IncludeFeaturedProductsInNormalLists { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to render link to required products in "Require other products added to the cart" warning
        /// </summary>
        public bool UseLinksInRequiredProductWarnings { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether tier prices should be displayed with applied discounts (if available)
        /// </summary>
        public bool DisplayTierPricesWithDiscounts { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to ignore discounts (side-wide). It can significantly improve performance when enabled.
        /// </summary>
        public bool IgnoreDiscounts { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to ignore featured products (side-wide). It can significantly improve performance when enabled.
        /// </summary>
        public bool IgnoreFeaturedProducts { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to ignore ACL rules (side-wide). It can significantly improve performance when enabled.
        /// </summary>
        public bool IgnoreAcl { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to ignore "limit per store" rules (side-wide). It can significantly improve performance when enabled.
        /// </summary>
        public bool IgnoreStoreLimitations { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to cache product prices. It can significantly improve performance when enabled.
        /// </summary>
        public bool CacheProductPrices { get; set; }

        /// <summary>
        /// Gets or sets a value indicating maximum number of 'back in stock' subscription
        /// </summary>
        public int MaximumBackInStockSubscriptions { get; set; }

        /// <summary>
        /// Gets or sets the value indicating how many manufacturers to display in manufacturers block
        /// </summary>
        public int ManufacturersBlockItemsToDisplay { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to display information about shipping and tax in the footer (used in Germany)
        /// </summary>
        public bool DisplayTaxShippingInfoFooter { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to display information about shipping and tax on product details pages (used in Germany)
        /// </summary>
        public bool DisplayTaxShippingInfoProductDetailsPage { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to display information about shipping and tax in product boxes (used in Germany)
        /// </summary>
        public bool DisplayTaxShippingInfoProductBoxes { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to display information about shipping and tax on shopping cart page (used in Germany)
        /// </summary>
        public bool DisplayTaxShippingInfoShoppingCart { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to display information about shipping and tax on wishlist page (used in Germany)
        /// </summary>
        public bool DisplayTaxShippingInfoWishlist { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to display information about shipping and tax on order details page (used in Germany)
        /// </summary>
        public bool DisplayTaxShippingInfoOrderDetailsPage { get; set; }

        /// <summary>
        /// Gets or sets the default value to use for Category page size options (for new categories)
        /// </summary>
        public string DefaultCategoryPageSizeOptions { get; set; }

        /// <summary>
        /// Gets or sets the default value to use for Category page size (for new categories)
        /// </summary>
        public int DefaultCategoryPageSize { get; set; }

        /// <summary>
        /// Gets or sets the default value to use for Manufacturer page size options (for new manufacturers)
        /// </summary>
        public string DefaultManufacturerPageSizeOptions { get; set; }

        /// <summary>
        /// Gets or sets the default value to use for Manufacturer page size (for new manufacturers)
        /// </summary>
        public int DefaultManufacturerPageSize { get; set; }

        /// <summary>
        /// Gets or sets a list of disabled values of ProductSortingEnum
        /// </summary>
        public List<int> ProductSortingEnumDisabled { get; set; }

        /// <summary>
        /// Gets or sets a display order of ProductSortingEnum values 
        /// </summary>
        public Dictionary<int, int> ProductSortingEnumDisplayOrder { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the products need to be exported/imported with their attributes
        /// </summary>
        public bool ExportImportProductAttributes { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether need to use "limited to stores" property for exported/imported products
        /// </summary>
        public bool ExportImportProductUseLimitedToStores { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the products need to be exported/imported with their specification attributes
        /// </summary>
        public bool ExportImportProductSpecificationAttributes { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether need create dropdown list for export
        /// </summary>
        public bool ExportImportUseDropdownlistsForAssociatedEntities { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the products should be exported/imported with a full category name including names of all its parents
        /// </summary>
        public bool ExportImportProductCategoryBreadcrumb { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the categories need to be exported/imported using name of category
        /// </summary>
        public bool ExportImportCategoriesUsingCategoryName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the images can be downloaded from remote server
        /// </summary>
        public bool ExportImportAllowDownloadImages { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether products must be importing by separated files
        /// </summary>
        public bool ExportImportSplitProductsFile { get; set; }

        /// <summary>
        /// Gets or sets a value of max products count in one file 
        /// </summary>
        public int ExportImportProductsCountInOneFile { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to remove required products from the cart if the main one is removed
        /// </summary>
        public bool RemoveRequiredProducts { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the related entities need to be exported/imported using name
        /// </summary>
        public bool ExportImportRelatedEntitiesByName { get; set; }

        /// <summary>
        /// Gets or sets count of displayed years for datepicker
        /// </summary>
        public int CountDisplayedYearsDatePicker { get; set; }

        /// <summary>
        /// Get or set a value indicating whether it's necessary to show the date for pre-order availability in a public store
        /// </summary>
        public bool DisplayDatePreOrderAvailability { get; set; }

        /// <summary>
        /// Get or set a value indicating whether use standart menu in public store or use Ajax to load menu
        /// </summary>
        public bool UseAjaxLoadMenu { get; set; }

    }
}
