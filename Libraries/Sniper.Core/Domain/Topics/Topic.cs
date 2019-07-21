using Sniper.Core.Domain.Localization;
using Sniper.Core.Domain.Security;
using Sniper.Core.Domain.Seo;
using Sniper.Core.Domain.Stores;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Topics
{
    public partial class Topic : BaseEntity, ILocalizedEntity, ISlugSupported, IStoreMappingSupported, IAclSupported
    {
        /// <summary>
        /// 系统名称
        /// </summary>
        public string SystemName { get; set; }

        /// <summary>
        /// 是否应将此主题包含在站点地图中
        /// </summary>
        public bool IncludeInSitemap { get; set; }

        /// <summary>
        /// 是否应将此主题包含在顶部菜单中
        /// </summary>
        public bool IncludeInTopMenu { get; set; }

        /// <summary>
        /// 是否应将此主题包含在页脚中（第1列）
        /// </summary>
        public bool IncludeInFooterColumn1 { get; set; }

        /// <summary>
        /// 是否应将此主题包含在页脚中（第2列）
        /// </summary>
        public bool IncludeInFooterColumn2 { get; set; }

        /// <summary>
        /// 是否应将此主题包含在页脚中（第2列）
        /// </summary>
        public bool IncludeInFooterColumn3 { get; set; }

        /// <summary>
        /// 展示顺序
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 关闭商店时是否可以访问此主题
        /// </summary>
        public bool AccessibleWhenStoreClosed { get; set; }

        /// <summary>
        /// 指示此主题是否受密码保护
        /// </summary>
        public bool IsPasswordProtected { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// body
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// 发布
        /// </summary>
        public bool Published { get; set; }

        /// <summary>
        /// topic模板
        /// </summary>
        public int TopicTemplateId { get; set; }

        /// <summary>
        /// 关键字
        /// </summary>
        public string MetaKeywords { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string MetaDescription { get; set; }

        /// <summary>
        /// MetaTitle
        /// </summary>
        public string MetaTitle { get; set; }

        /// <summary>
        /// 实体是否受ACL限制
        /// </summary>
        public bool SubjectToAcl { get; set; }

        /// <summary>
        /// 该实体是否受限于某些商店
        /// </summary>
        public bool LimitedToStores { get; set; }

    }
}
