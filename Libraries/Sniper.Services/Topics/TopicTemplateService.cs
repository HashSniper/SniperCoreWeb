using System;
using System.Collections.Generic;
using System.Text;
using Sniper.Core.Data;
using Sniper.Core.Domain.Topics;
using Sniper.Services.Events;

namespace Sniper.Services.Topics
{
    public partial class TopicTemplateService : ITopicTemplateService
    {
        #region Fields

        private readonly IEventPublisher _eventPublisher;
        private readonly IRepository<TopicTemplate> _topicTemplateRepository;

        #endregion

        #region Ctor

        public TopicTemplateService(IEventPublisher eventPublisher,
            IRepository<TopicTemplate> topicTemplateRepository)
        {
            _eventPublisher = eventPublisher;
            _topicTemplateRepository = topicTemplateRepository;
        }

        #endregion

        #region Methods
        public void DeleteTopicTemplate(TopicTemplate topicTemplate)
        {
            throw new NotImplementedException();
        }

        public IList<TopicTemplate> GetAllTopicTemplates()
        {
            throw new NotImplementedException();
        }

        public TopicTemplate GetTopicTemplateById(int topicTemplateId)
        {
            throw new NotImplementedException();
        }

        public void InsertTopicTemplate(TopicTemplate topicTemplate)
        {
            throw new NotImplementedException();
        }

        public void UpdateTopicTemplate(TopicTemplate topicTemplate)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
