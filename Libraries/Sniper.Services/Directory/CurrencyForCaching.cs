using Sniper.Core.Caching;
using Sniper.Core.Domain.Directory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sniper.Services.Directory
{
    [Serializable]
    [NotMapped]
    public class CurrencyForCaching : Currency, IEntityForCaching
    {
        public CurrencyForCaching()
        {
        }

        public CurrencyForCaching(Currency c)
        {
            Id = c.Id;
            Name = c.Name;
            CurrencyCode = c.CurrencyCode;
            Rate = c.Rate;
            DisplayLocale = c.DisplayLocale;
            CustomFormatting = c.CustomFormatting;
            LimitedToStores = c.LimitedToStores;
            Published = c.Published;
            DisplayOrder = c.DisplayOrder;
            CreatedOnUtc = c.CreatedOnUtc;
            UpdatedOnUtc = c.UpdatedOnUtc;
            RoundingTypeId = c.RoundingTypeId;
        }
    }
}
