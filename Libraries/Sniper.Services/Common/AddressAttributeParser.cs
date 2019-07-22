using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Sniper.Core.Domain.Common;
using Sniper.Services.Localization;

namespace Sniper.Services.Common
{
    public partial class AddressAttributeParser : IAddressAttributeParser
    {
        #region Fields

        private readonly IAddressAttributeService _addressAttributeService;
        private readonly ILocalizationService _localizationService;

        #endregion

        #region Ctor

        public AddressAttributeParser(IAddressAttributeService addressAttributeService,
            ILocalizationService localizationService)
        {
            _addressAttributeService = addressAttributeService;
            _localizationService = localizationService;
        }

        #endregion

        #region Methods
        public string AddAddressAttribute(string attributesXml, AddressAttribute attribute, string value)
        {
            throw new NotImplementedException();
        }

        public IList<string> GetAttributeWarnings(string attributesXml)
        {
            throw new NotImplementedException();
        }

        public IList<AddressAttribute> ParseAddressAttributes(string attributesXml)
        {
            throw new NotImplementedException();
        }

        public IList<AddressAttributeValue> ParseAddressAttributeValues(string attributesXml)
        {
            throw new NotImplementedException();
        }

        public string ParseCustomAddressAttributes(IFormCollection form)
        {
            throw new NotImplementedException();
        }

        public IList<string> ParseValues(string attributesXml, int addressAttributeId)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
