using Sniper.Core.Caching;
using Sniper.Core.Domain.Stores;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sniper.Services.Stores
{
    [NotMapped]
    public class StoreForCaching : Store, IEntityForCaching
    {
        public StoreForCaching()
        {
        }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="s">Store to copy</param>
        public StoreForCaching(Store s)
        {
            Id = s.Id;
            Name = s.Name;
            Url = s.Url;
            SslEnabled = s.SslEnabled;
            Hosts = s.Hosts;
            DefaultLanguageId = s.DefaultLanguageId;
            DisplayOrder = s.DisplayOrder;
            CompanyName = s.CompanyName;
            CompanyAddress = s.CompanyAddress;
            CompanyPhoneNumber = s.CompanyPhoneNumber;
            CompanyVat = s.CompanyVat;
        }
    }
}
