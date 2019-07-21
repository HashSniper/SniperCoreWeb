using Sniper.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Forums
{
    public class ForumSettings : ISettings
    {
        /// <summary>
        /// 论坛是否已启用
        /// </summary>
        public bool ForumsEnabled { get; set; }

        /// <summary>
        /// 是否启用了相对日期和时间格式（例如，2小时前，一个月前）
        /// </summary>
        public bool RelativeDateTimeFormattingEnabled { get; set; }

        /// <summary>
        /// 是否允许客户编辑他们创建的帖子
        /// </summary>
        public bool AllowCustomersToEditPosts { get; set; }

        /// <summary>
        /// 是否允许客户管理其订阅
        /// </summary>
        public bool AllowCustomersToManageSubscriptions { get; set; }

        /// <summary>
        /// 是否允许客人创建帖子
        /// </summary>
        public bool AllowGuestsToCreatePosts { get; set; }

        /// <summary>
        /// 是否允许客人创建主题
        /// </summary>
        public bool AllowGuestsToCreateTopics { get; set; }

        /// <summary>
        /// 是否允许客户删除他们创建的帖子
        /// </summary>
        public bool AllowCustomersToDeletePosts { get; set; }

        /// <summary>
        /// 用户是否可以投票
        /// </summary>
        public bool AllowPostVoting { get; set; }

        /// <summary>
        /// 每天用户的最大投票数
        /// </summary>
        public int MaxVotesPerDay { get; set; }

        /// <summary>
        /// 主题的最大长度
        /// </summary>
        public int TopicSubjectMaxLength { get; set; }

        /// <summary>
        /// 剥离的论坛主题名称的最大长度
        /// </summary>
        public int StrippedTopicMaxLength { get; set; }

        /// <summary>
        /// 最大长度
        /// </summary>
        public int PostMaxLength { get; set; }

        /// <summary>
        /// 论坛主题的页面大小
        /// </summary>
        public int TopicsPageSize { get; set; }

        /// <summary>
        /// 主题中帖子的页面大小
        /// </summary>
        public int PostsPageSize { get; set; }

        /// <summary>
        /// 搜索结果的页面大小
        /// </summary>
        public int SearchResultsPageSize { get; set; }

        /// <summary>
        /// Active Discussions页面的页面大小
        /// </summary>
        public int ActiveDiscussionsPageSize { get; set; }

        /// <summary>
        /// 最新客户帖子的页面大小
        /// </summary>
        public int LatestCustomerPostsPageSize { get; set; }

        /// <summary>
        /// 是否向客户展示论坛帖子数量
        /// </summary>
        public bool ShowCustomersPostCount { get; set; }

        /// <summary>
        /// 论坛编辑器类型
        /// </summary>
        public EditorType ForumEditor { get; set; }

        /// <summary>
        /// 是否允许客户指定签名
        /// </summary>
        public bool SignaturesEnabled { get; set; }

        /// <summary>
        /// 是否允许私信
        /// </summary>
        public bool AllowPrivateMessages { get; set; }

        /// <summary>
        /// 是否应显示新私人消息的警报
        /// </summary>
        public bool ShowAlertForPM { get; set; }

        /// <summary>
        /// 私人消息的页面大小
        /// </summary>
        public int PrivateMessagesPageSize { get; set; }

        /// <summary>
        /// （我的帐户）论坛订阅的页面大小
        /// </summary>
        public int ForumSubscriptionsPageSize { get; set; }

        /// <summary>
        /// 是否应通知客户有关新的私人消息
        /// </summary>
        public bool NotifyAboutPrivateMessages { get; set; }

        /// <summary>
        /// pm主题的最大长度
        /// </summary>
        public int PMSubjectMaxLength { get; set; }

        /// <summary>
        /// pm消息的最大长度
        /// </summary>
        public int PMTextMaxLength { get; set; }

        /// <summary>
        /// 论坛主页上为Active Discussions显示的项目数
        /// </summary>
        public int HomepageActiveDiscussionsTopicCount { get; set; }

        /// <summary>
        /// Active Discussions RSS Feed显示的项目数
        /// </summary>
        public int ActiveDiscussionsFeedCount { get; set; }

        /// <summary>
        /// 是否启用了Active Discussions RSS Feed
        /// </summary>
        public bool ActiveDiscussionsFeedEnabled { get; set; }

        /// <summary>
        /// 论坛是否启用了RSS Feed
        /// </summary>
        public bool ForumFeedsEnabled { get; set; }

        /// <summary>
        /// 论坛RSS Feed显示的项目数
        /// </summary>
        public int ForumFeedCount { get; set; }

        /// <summary>
        /// 搜索字词的最小长度
        /// </summary>
        public int ForumSearchTermMinimumLength { get; set; }

    }
}
