using Sniper.Core.Domain.Topics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Services.Topics
{
    public partial interface ITopicService
    {
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="topic"></param>
        void DeleteTopic(Topic topic);

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="topicId"></param>
        /// <returns></returns>
        Topic GetTopicById(int topicId);

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="systemName"></param>
        /// <param name="storeId"></param>
        /// <param name="showHidden"></param>
        /// <returns></returns>
        Topic GetTopicBySystemName(string systemName, int storeId = 0, bool showHidden = false);

        /// <summary>
        /// 获取所有
        /// </summary>
        /// <param name="storeId"></param>
        /// <param name="ignorAcl"></param>
        /// <param name="showHidden"></param>
        /// <returns></returns>
        IList<Topic> GetAllTopics(int storeId, bool ignorAcl = false, bool showHidden = false);

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="topic"></param>
        void InsertTopic(Topic topic);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="topic"></param>
        void UpdateTopic(Topic topic);

    }
}
