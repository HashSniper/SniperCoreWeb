using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Sniper.Core;
using Sniper.Core.Domain.Customers;
using Sniper.Services.Common;
using Sniper.Services.Configuration;

namespace Sniper.Services.Helpers
{
    public partial class DateTimeHelper : IDateTimeHelper
    {
        #region Fields

        private readonly DateTimeSettings _dateTimeSettings;
        private readonly IGenericAttributeService _genericAttributeService;
        private readonly ISettingService _settingService;
        private readonly IWorkContext _workContext;

        #endregion

        #region Ctor

        public DateTimeHelper(DateTimeSettings dateTimeSettings,
            IGenericAttributeService genericAttributeService,
            ISettingService settingService,
            IWorkContext workContext)
        {
            _dateTimeSettings = dateTimeSettings;
            _genericAttributeService = genericAttributeService;
            _settingService = settingService;
            _workContext = workContext;
        }

        #endregion

        #region Methods
        public TimeZoneInfo DefaultStoreTimeZone { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public TimeZoneInfo CurrentTimeZone { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public DateTime ConvertToUserTime(DateTime dt)
        {
            throw new NotImplementedException();
        }

        public DateTime ConvertToUserTime(DateTime dt, DateTimeKind sourceDateTimeKind)
        {
            throw new NotImplementedException();
        }

        public DateTime ConvertToUserTime(DateTime dt, TimeZoneInfo sourceTimeZone)
        {
            throw new NotImplementedException();
        }

        public DateTime ConvertToUserTime(DateTime dt, TimeZoneInfo sourceTimeZone, TimeZoneInfo destinationTimeZone)
        {
            throw new NotImplementedException();
        }

        public DateTime ConvertToUtcTime(DateTime dt)
        {
            throw new NotImplementedException();
        }

        public DateTime ConvertToUtcTime(DateTime dt, DateTimeKind sourceDateTimeKind)
        {
            throw new NotImplementedException();
        }

        public DateTime ConvertToUtcTime(DateTime dt, TimeZoneInfo sourceTimeZone)
        {
            throw new NotImplementedException();
        }

        public TimeZoneInfo FindTimeZoneById(string id)
        {
            throw new NotImplementedException();
        }

        public TimeZoneInfo GetCustomerTimeZone(Customer customer)
        {
            throw new NotImplementedException();
        }

        public ReadOnlyCollection<TimeZoneInfo> GetSystemTimeZones()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
