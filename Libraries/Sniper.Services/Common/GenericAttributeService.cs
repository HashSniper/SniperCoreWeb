using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sniper.Core;
using Sniper.Core.Caching;
using Sniper.Core.Data;
using Sniper.Core.Domain.Common;
using Sniper.Data.EntityExtensions;
using Sniper.Services.Events;

namespace Sniper.Services.Common
{
    public partial class GenericAttributeService : IGenericAttributeService
    {
        #region Fields

        private readonly ICacheManager _cacheManager;
        private readonly IEventPublisher _eventPublisher;
        private readonly IRepository<GenericAttribute> _genericAttributeRepository;

        #endregion

        #region Ctor

        public GenericAttributeService(ICacheManager cacheManager,
            IEventPublisher eventPublisher,
            IRepository<GenericAttribute> genericAttributeRepository)
        {
            _cacheManager = cacheManager;
            _eventPublisher = eventPublisher;
            _genericAttributeRepository = genericAttributeRepository;
        }

        #endregion

        #region Methods
        public void DeleteAttribute(GenericAttribute attribute)
        {
            throw new NotImplementedException();
        }

        public void DeleteAttributes(IList<GenericAttribute> attributes)
        {
            throw new NotImplementedException();
        }

        public TPropType GetAttribute<TPropType>(BaseEntity entity, string key, int storeId = 0, TPropType defaultValue = default)
        {
            if(entity==null)
                throw new ArgumentNullException(nameof(entity));

            var keyGroup = entity.GetUnproxiedEntityType().Name;

            var props = GetAttributesForEntity(entity.Id, keyGroup);

            if (props == null)
            {
                return defaultValue;
            }

            props = props.Where(x => x.StoreId == storeId).ToList();

            if (!props.Any())
            {
                return defaultValue;
            }

            var prop = props.FirstOrDefault(ga => ga.Key.Equals(key, StringComparison.InvariantCultureIgnoreCase));

            if (prop == null || string.IsNullOrEmpty(prop.Value))
            {
                return defaultValue;
            }

            return CommonHelper.To<TPropType>(prop.Value);
        }

        public GenericAttribute GetAttributeById(int attributeId)
        {
            throw new NotImplementedException();
        }

        public IList<GenericAttribute> GetAttributesForEntity(int entityId, string keyGroup)
        {
            var key = string.Format(NopCommonDefaults.GenericAttributeCacheKey, entityId, keyGroup);

            return _cacheManager.Get(key, () =>
             {
                 var query = from ga in _genericAttributeRepository.Table
                             where ga.EntityId == entityId && ga.KeyGroup == keyGroup
                             select ga;

                 var attributes = query.ToList();
                 return attributes;
             });
        }

        public void InsertAttribute(GenericAttribute attribute)
        {
            throw new NotImplementedException();
        }

        public void SaveAttribute<TPropType>(BaseEntity entity, string key, TPropType value, int storeId = 0)
        {
            throw new NotImplementedException();
        }

        public void UpdateAttribute(GenericAttribute attribute)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
