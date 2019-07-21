using Sniper.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Blogs
{
    public class BlogSettings : ISettings
    {
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// 帖子的页面大小
        /// </summary>
        public int PostsPageSize { get; set; }

        /// <summary>
        /// 未注册用户是否可以发表评论
        /// </summary>
        public bool AllowNotRegisteredUsersToLeaveComments { get; set; }

        /// <summary>
        /// 是否通知新的博客评论
        /// </summary>
        public bool NotifyAboutNewBlogComments { get; set; }

        /// <summary>
        /// 许多博客标签出现在标签云中
        /// </summary>
        public int NumberOfTags { get; set; }

        /// <summary>
        /// 在客户浏览器地址栏中启用博客RSS提要链接
        /// </summary>
        public bool ShowHeaderRssUrl { get; set; }

        /// <summary>
        /// 是否必须批准博客评论
        /// </summary>
        public bool BlogCommentsMustBeApproved { get; set; }

        /// <summary>
        /// 是否将按商店过滤博客评论
        /// </summary>
        public bool ShowBlogCommentsPerStore { get; set; }

    }
}
