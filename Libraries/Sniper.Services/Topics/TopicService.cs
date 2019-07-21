using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sniper.Core;
using Sniper.Core.Caching;
using Sniper.Core.Data;
using Sniper.Core.Domain.Catalog;
using Sniper.Core.Domain.Security;
using Sniper.Core.Domain.Stores;
using Sniper.Core.Domain.Topics;
using Sniper.Services.Events;
using Sniper.Services.Security;
using Sniper.Services.Stores;

namespace Sniper.Services.Topics
{
    public partial class TopicService : ITopicService
    {
        #region Fields

        private readonly CatalogSettings _catalogSettings;
        private readonly IAclService _aclService;
        private readonly ICacheManager _cacheManager;
        private readonly IEventPublisher _eventPublisher;
        private readonly IRepository<AclRecord> _aclRepository;
        private readonly IRepository<StoreMapping> _storeMappingRepository;
        private readonly IRepository<Topic> _topicRepository;
        private readonly IStoreMappingService _storeMappingService;
        private readonly IWorkContext _workContext;

        #endregion

        #region Ctor

        public TopicService(CatalogSettings catalogSettings,
            IAclService aclService,
            ICacheManager cacheManager,
            IEventPublisher eventPublisher,
            IRepository<AclRecord> aclRepository,
            IRepository<StoreMapping> storeMappingRepository,
            IRepository<Topic> topicRepository,
            IStoreMappingService storeMappingService,
            IWorkContext workContext)
        {
            _catalogSettings = catalogSettings;
            _aclService = aclService;
            _cacheManager = cacheManager;
            _eventPublisher = eventPublisher;
            _aclRepository = aclRepository;
            _storeMappingRepository = storeMappingRepository;
            _topicRepository = topicRepository;
            _storeMappingService = storeMappingService;
            _workContext = workContext;
        }

        #endregion

        #region Methods
        public void DeleteTopic(Topic topic)
        {
            throw new NotImplementedException();
        }

        public IList<Topic> GetAllTopics(int storeId, bool ignorAcl = false, bool showHidden = false)
        {
            throw new NotImplementedException();
        }

        public Topic GetTopicById(int topicId)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        ///获取Topic
        /// </summary>
        /// <param name="systemName"></param>
        /// <param name="storeId"></param>
        /// <param name="showHidden"></param>
        /// <returns></returns>
        public virtual Topic GetTopicBySystemName(string systemName, int storeId = 0, bool showHidden = false)
        {
            if (string.IsNullOrEmpty(systemName))
                return null;

            var query = _topicRepository.Table;
            query = query.Where(t => t.SystemName == systemName);

            if (!showHidden)
                query = query.Where(x => x.Published);

            query = query.OrderBy(t => t.Id);

            var topics = query.ToList();

            if (storeId > 0)
            {
                topics = topics.Where(x => _storeMappingService.Authorize(x, storeId)).ToList();
            }

            if (!showHidden)
            {
                topics = topics.Where(x => _aclService.Authorize(x)).ToList();
            }

            return topics.FirstOrDefault();
        }

        public void InsertTopic(Topic topic)
        {
            throw new NotImplementedException();
        }

        public void UpdateTopic(Topic topic)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
