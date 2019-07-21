using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sniper.Core;
using Sniper.Core.Caching;
using Sniper.Core.Domain.Customers;
using Sniper.Core.Domain.Topics;
using Sniper.Services.Localization;
using Sniper.Services.Security;
using Sniper.Services.Seo;
using Sniper.Services.Stores;
using Sniper.Services.Topics;
using Sniper.Web.Infrastructure.Cache;
using Sniper.Web.Models.Topics;

namespace Sniper.Web.Factories
{
    public partial class TopicModelFactory : ITopicModelFactory
    {
        #region Fields

        private readonly IAclService _aclService;
        private readonly ILocalizationService _localizationService;
        private readonly IStaticCacheManager _cacheManager;
        private readonly IStoreContext _storeContext;
        private readonly IStoreMappingService _storeMappingService;
        private readonly ITopicService _topicService;
        private readonly ITopicTemplateService _topicTemplateService;
        private readonly IUrlRecordService _urlRecordService;
        private readonly IWorkContext _workContext;

        #endregion

        #region Ctor

        public TopicModelFactory(IAclService aclService,
            ILocalizationService localizationService,
            IStaticCacheManager cacheManager,
            IStoreContext storeContext,
            IStoreMappingService storeMappingService,
            ITopicService topicService,
            ITopicTemplateService topicTemplateService,
            IUrlRecordService urlRecordService,
            IWorkContext workContext)
        {
            _aclService = aclService;
            _localizationService = localizationService;
            _cacheManager = cacheManager;
            _storeContext = storeContext;
            _storeMappingService = storeMappingService;
            _topicService = topicService;
            _topicTemplateService = topicTemplateService;
            _urlRecordService = urlRecordService;
            _workContext = workContext;
        }

        #endregion


        #region Methods
        public string PrepareTemplateViewPath(int topicTemplateId)
        {
            throw new NotImplementedException();
        }

        public TopicModel PrepareTopicModelById(int topicId, bool showHidden = false)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 按主题系统名称获取主题模型
        /// </summary>
        /// <param name="systemName"></param>
        /// <returns></returns>
        public virtual TopicModel PrepareTopicModelBySystemName(string systemName)
        {
            var cacheKey = string.Format(NopModelCacheDefaults.TopicModelBySystemNameKey,
                systemName,
                _workContext.WorkingLanguage.Id,
                _storeContext.CurrentStore.Id,
                string.Join(",", _workContext.CurrentCustomer.GetCustomerRoleIds()));

            var cachedModel = _cacheManager.Get(cacheKey, () =>
               {
                   var topic = _topicService.GetTopicBySystemName(systemName, _storeContext.CurrentStore.Id);

                   if (topic == null)
                   {
                       return null;
                   }

                   return PrepareTopicModel(topic);
               });

            return cachedModel;
        }


        #endregion

        #region Utilities
        /// <summary>
        /// 准备主题模型
        /// </summary>
        /// <param name="topic"></param>
        /// <returns></returns>
        protected virtual TopicModel PrepareTopicModel(Topic topic)
        {
            if (topic == null)
            {
                throw new ArgumentNullException(nameof(topic));
            }

            var model = new TopicModel
            {
                Id = topic.Id,
                SystemName = topic.SystemName,
                IncludeInSitemap = topic.IncludeInSitemap,
                IsPasswordProtected = topic.IsPasswordProtected,
                Title = topic.IsPasswordProtected ? "" : _localizationService.GetLocalized(topic, x => x.Title),
                Body = topic.IsPasswordProtected ? "" : _localizationService.GetLocalized(topic, x => x.Body),
                MetaKeywords = _localizationService.GetLocalized(topic, x => x.MetaKeywords),
                MetaDescription = _localizationService.GetLocalized(topic, x => x.MetaDescription),
                MetaTitle = _localizationService.GetLocalized(topic, x => x.MetaTitle),
                SeName = _urlRecordService.GetSeName(topic),
                TopicTemplateId = topic.TopicTemplateId
            };
            return model;
        }
        #endregion
    }
}
