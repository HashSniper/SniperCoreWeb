using Sniper.Core.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Services.Authentication
{
    public partial interface IAuthenticationService
    {
        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="isPersistent"></param>
        void SignIn(Customer customer, bool isPersistent);

        /// <summary>
        /// 登出
        /// </summary>
        void SignOut();

        /// <summary>
        /// 获得经过身份验证的客户
        /// </summary>
        /// <returns></returns>
        Customer GetAuthenticatedCustomer();

    }
}
