using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sniper.Core;
using Sniper.Core.Caching;
using Sniper.Core.Data;
using Sniper.Core.Domain.Customers;
using Sniper.Core.Domain.Security;
using Sniper.Services.Customers;
using Sniper.Services.Localization;

namespace Sniper.Services.Security
{
    public partial class PermissionService : IPermissionService
    {
        #region Fields

        private readonly ICacheManager _cacheManager;
        private readonly ICustomerService _customerService;
        private readonly ILocalizationService _localizationService;
        private readonly IRepository<PermissionRecord> _permissionRecordRepository;
        private readonly IRepository<PermissionRecordCustomerRoleMapping> _permissionRecordCustomerRoleMappingRepository;
        private readonly IStaticCacheManager _staticCacheManager;
        private readonly IWorkContext _workContext;

        #endregion

        #region Ctor

        public PermissionService(ICacheManager cacheManager,
            ICustomerService customerService,
            ILocalizationService localizationService,
            IRepository<PermissionRecord> permissionRecordRepository,
            IRepository<PermissionRecordCustomerRoleMapping> permissionRecordCustomerRoleMappingRepository,
            IStaticCacheManager staticCacheManager,
            IWorkContext workContext)
        {
            _cacheManager = cacheManager;
            _customerService = customerService;
            _localizationService = localizationService;
            _permissionRecordRepository = permissionRecordRepository;
            _permissionRecordCustomerRoleMappingRepository = permissionRecordCustomerRoleMappingRepository;
            _staticCacheManager = staticCacheManager;
            _workContext = workContext;
        }

        #endregion

        #region Methods

        /// <summary>
        /// 授权许可
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        public virtual bool Authorize(PermissionRecord permission)
        {
            return Authorize(permission, _workContext.CurrentCustomer);
        }

        public virtual bool Authorize(PermissionRecord permission, Customer customer)
        {
            if (permission == null)
                return false;

            if (customer == null)
                return false;         

            return Authorize(permission.SystemName, customer);
        }

        public virtual bool Authorize(string permissionRecordSystemName)
        {
            throw new NotImplementedException();
        }

        public virtual bool Authorize(string permissionRecordSystemName, Customer customer)
        {
            if (string.IsNullOrEmpty(permissionRecordSystemName))
                return false;

            var customerRoles = customer.CustomerRoles.Where(cr => cr.Active);
            foreach (var role in customerRoles)
                if (Authorize(permissionRecordSystemName, role.Id))
                    //yes, we have such permission
                    return true;

            //no permission found
            return false;
        }

        public void DeletePermissionRecord(PermissionRecord permission)
        {
            throw new NotImplementedException();
        }

        public IList<PermissionRecord> GetAllPermissionRecords()
        {
            throw new NotImplementedException();
        }

        public PermissionRecord GetPermissionRecordById(int permissionId)
        {
            throw new NotImplementedException();
        }

        public PermissionRecord GetPermissionRecordBySystemName(string systemName)
        {
            throw new NotImplementedException();
        }

        public void InsertPermissionRecord(PermissionRecord permission)
        {
            throw new NotImplementedException();
        }

        public void InstallPermissions(IPermissionProvider permissionProvider)
        {
            throw new NotImplementedException();
        }

        public void UninstallPermissions(IPermissionProvider permissionProvider)
        {
            throw new NotImplementedException();
        }

        public void UpdatePermissionRecord(PermissionRecord permission)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Utilities
        protected virtual bool Authorize(string permissionRecordSystemName, int customerRoleId)
        {
            if (string.IsNullOrEmpty(permissionRecordSystemName))
                return false;

            var key = string.Format(NopSecurityDefaults.PermissionsAllowedCacheKey, customerRoleId, permissionRecordSystemName);

            return _staticCacheManager.Get(key, () =>
             {
                 var permissions = GetPermissionRecordsByCustomerRoleId(customerRoleId);

                 foreach (var permission1 in permissions)
                     if (permission1.SystemName.Equals(permissionRecordSystemName, StringComparison.InvariantCultureIgnoreCase))
                         return true;

                 return false;
             });
        }

        /// <summary>
        /// 按客户角色标识获取权限记录
        /// </summary>
        /// <param name="customerRoleId"></param>
        /// <returns></returns>
        protected virtual IList<PermissionRecord> GetPermissionRecordsByCustomerRoleId(int customerRoleId)
        {
            var key = string.Format(NopSecurityDefaults.PermissionsAllByCustomerRoleIdCacheKey, customerRoleId);
            return _cacheManager.Get(key, () =>
                 {
                     var query = from pr in _permissionRecordRepository.Table
                                 join prcrm in _permissionRecordCustomerRoleMappingRepository.Table on pr.Id equals prcrm.PermissionRecordId
                                 where prcrm.CustomerRoleId == customerRoleId
                                 orderby pr.Id
                                 select pr;
                     return query.ToList();
                 });
        }
        #endregion
    }
}
