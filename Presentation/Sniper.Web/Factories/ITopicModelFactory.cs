using Sniper.Web.Models.Topics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sniper.Web.Factories
{
    public partial interface ITopicModelFactory
    {
        /// <summary>
        /// 按主题标识获取主题模型
        /// </summary>
        /// <param name="topicId"></param>
        /// <param name="showHidden"></param>
        /// <returns></returns>
        TopicModel PrepareTopicModelById(int topicId, bool showHidden = false);

        /// <summary>
        /// 按主题系统名称获取主题模型
        /// </summary>
        /// <param name="systemName"></param>
        /// <returns></returns>
        TopicModel PrepareTopicModelBySystemName(string systemName);

        /// <summary>
        /// 获取主题模板视图路径
        /// </summary>
        /// <param name="topicTemplateId"></param>
        /// <returns></returns>
        string PrepareTemplateViewPath(int topicTemplateId);

    }
}
