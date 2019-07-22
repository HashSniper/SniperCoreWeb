using Sniper.Services.Plugins;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Services.Tax
{
    /// <summary>
    /// 提供用于创建税务提供者的接口
    /// </summary>
    public partial interface ITaxProvider : IPlugin
    {
        /// <summary>
        /// Gets tax rate
        /// </summary>
        /// <param name="calculateTaxRequest">Tax calculation request</param>
        /// <returns>Tax</returns>
        CalculateTaxResult GetTaxRate(CalculateTaxRequest calculateTaxRequest);
    }
}
