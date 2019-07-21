using Sniper.Core.Domain.Topics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Services.Topics
{
    public partial interface ITopicTemplateService
    {
        /// <summary>
        /// 删除模板
        /// </summary>
        /// <param name="topicTemplate"></param>
        void DeleteTopicTemplate(TopicTemplate topicTemplate);

        /// <summary>
        /// 获取
        /// </summary>
        /// <returns></returns>
        IList<TopicTemplate> GetAllTopicTemplates();

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="topicTemplateId"></param>
        /// <returns></returns>
        TopicTemplate GetTopicTemplateById(int topicTemplateId);

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="topicTemplate"></param>
        void InsertTopicTemplate(TopicTemplate topicTemplate);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="topicTemplate"></param>
        void UpdateTopicTemplate(TopicTemplate topicTemplate);

    }
}
