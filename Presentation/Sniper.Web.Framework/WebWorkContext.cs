using Sniper.Core;
using Sniper.Core.Domain.Customers;
using Sniper.Core.Domain.Directory;
using Sniper.Core.Domain.Localization;
using Sniper.Core.Domain.Tax;
using Sniper.Core.Domain.Vendors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Web.Framework
{
    public partial class WebWorkContext : IWorkContext
    {
        public Customer CurrentCustomer { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Customer OriginalCustomerIfImpersonated => throw new NotImplementedException();

        public Vendor CurrentVendor => throw new NotImplementedException();

        public Language WorkingLanguage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Currency WorkingCurrency { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public TaxDisplayType TaxDisplayType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsAdmin { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
