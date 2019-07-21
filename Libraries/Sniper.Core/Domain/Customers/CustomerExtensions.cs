using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sniper.Core.Domain.Customers
{
    public static class CustomerExtensions
    {
        /// <summary>
        /// 判断是否被注册
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="onlyActiveCustomerRoles"></param>
        /// <returns></returns>
        public static bool IsRegistered(this Customer customer, bool onlyActiveCustomerRoles = true)
        {
            return IsInCustomerRole(customer, NopCustomerDefaults.RegisteredRoleName, onlyActiveCustomerRoles);
        }

        /// <summary>
        /// 客户是否担任某个客户角色
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="customerRoleSystemName"></param>
        /// <param name="onlyActiveCustomerRoles"></param>
        /// <returns></returns>
        public static bool IsInCustomerRole(this Customer customer, string customerRoleSystemName, bool onlyActiveCustomerRoles = true)
        {
            if (customer == null)
                throw new ArgumentNullException(nameof(customer));

            if (string.IsNullOrEmpty(customerRoleSystemName))
                throw new ArgumentNullException(nameof(customerRoleSystemName));

            var result = customer.CustomerRoles.FirstOrDefault(p => (!onlyActiveCustomerRoles || p.Active) && p.SystemName == customerRoleSystemName) != null;
            return result;
        }

        /// <summary>
        /// 获取客户角色标识符
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="showHidden"></param>
        /// <returns></returns>
        public static int[] GetCustomerRoleIds(this Customer customer, bool showHidden = false)
        {
            if(customer==null)
                throw new ArgumentNullException(nameof(customer));

            var customerRolesIds = customer.CustomerRoles
                .Where(cr => showHidden || cr.Active)
                .Select(cr => cr.Id)
                .ToArray();

            return customerRolesIds;
        }
    }
}
