using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sniper.Core;
using Sniper.Core.Caching;
using Sniper.Core.Data;
using Sniper.Core.Domain.Catalog;
using Sniper.Core.Domain.Customers;
using Sniper.Core.Domain.Security;
using Sniper.Data.EntityExtensions;
using Sniper.Services.Events;

namespace Sniper.Services.Security
{
    public partial class AclService : IAclService
    {
        #region Fields

        private readonly CatalogSettings _catalogSettings;
        private readonly IEventPublisher _eventPublisher;
        private readonly IRepository<AclRecord> _aclRecordRepository;
        private readonly IStaticCacheManager _cacheManager;
        private readonly IWorkContext _workContext;

        #endregion

        #region Ctor

        public AclService(CatalogSettings catalogSettings,
            IEventPublisher eventPublisher,
            IRepository<AclRecord> aclRecordRepository,
            IStaticCacheManager cacheManager,
            IWorkContext workContext)
        {
            _catalogSettings = catalogSettings;
            _eventPublisher = eventPublisher;
            _aclRecordRepository = aclRecordRepository;
            _cacheManager = cacheManager;
            _workContext = workContext;
        }

        #endregion

        #region Methods

        /// <summary>
        /// 授权ACL权限
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual bool Authorize<T>(T entity) where T : BaseEntity, IAclSupported
        {
            return Authorize(entity, _workContext.CurrentCustomer);
        }

        public virtual bool Authorize<T>(T entity, Customer customer) where T : BaseEntity, IAclSupported
        {
            if (entity == null)
                return false;

            if (customer == null)
                return false;

            if (_catalogSettings.IgnoreAcl)
                return true;

            if (!entity.SubjectToAcl)
                return true;

            foreach (var role1 in customer.CustomerRoles.Where(cr => cr.Active))
            {
                foreach (var role2Id in GetCustomerRoleIdsWithAccess(entity))
                {
                    if (role1.Id == role2Id)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public void DeleteAclRecord(AclRecord aclRecord)
        {
            throw new NotImplementedException();
        }

        public AclRecord GetAclRecordById(int aclRecordId)
        {
            throw new NotImplementedException();
        }

        public IList<AclRecord> GetAclRecords<T>(T entity) where T : BaseEntity, IAclSupported
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 查找已授予访问权限的客户角色标识
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int[] GetCustomerRoleIdsWithAccess<T>(T entity) where T : BaseEntity, IAclSupported
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var entityId = entity.Id;

            var entityName = entity.GetUnproxiedEntityType().Name;

            var key = string.Format(NopSecurityDefaults.AclRecordByEntityIdNameCacheKey, entityId, entityName);

            return _cacheManager.Get(key, () =>
             {
                 var query = from ur in _aclRecordRepository.Table
                             where ur.EntityId == entityId
                             && ur.EntityName == entityName
                             select ur.CustomerRoleId;

                 return query.ToArray();
             });
        }

        public void InsertAclRecord(AclRecord aclRecord)
        {
            throw new NotImplementedException();
        }

        public void InsertAclRecord<T>(T entity, int customerRoleId) where T : BaseEntity, IAclSupported
        {
            throw new NotImplementedException();
        }

        public void UpdateAclRecord(AclRecord aclRecord)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
