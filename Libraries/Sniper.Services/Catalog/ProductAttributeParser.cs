using System;
using System.Collections.Generic;
using System.Text;
using Sniper.Core.Domain.Catalog;
using Sniper.Data;

namespace Sniper.Services.Catalog
{
    public partial class ProductAttributeParser : IProductAttributeParser
    {
        #region Fields

        private readonly IDbContext _context;
        private readonly IProductAttributeService _productAttributeService;

        #endregion

        #region Ctor

        public ProductAttributeParser(IDbContext context,
            IProductAttributeService productAttributeService)
        {
            _context = context;
            _productAttributeService = productAttributeService;
        }

        #endregion

        #region Methods
        public string AddGiftCardAttribute(string attributesXml, string recipientName, string recipientEmail, string senderName, string senderEmail, string giftCardMessage)
        {
            throw new NotImplementedException();
        }

        public string AddProductAttribute(string attributesXml, ProductAttributeMapping productAttributeMapping, string value, int? quantity = null)
        {
            throw new NotImplementedException();
        }

        public bool AreProductAttributesEqual(string attributesXml1, string attributesXml2, bool ignoreNonCombinableAttributes, bool ignoreQuantity = true)
        {
            throw new NotImplementedException();
        }

        public ProductAttributeCombination FindProductAttributeCombination(Product product, string attributesXml, bool ignoreNonCombinableAttributes = true)
        {
            throw new NotImplementedException();
        }

        public IList<string> GenerateAllCombinations(Product product, bool ignoreNonCombinableAttributes = false, IList<int> allowedAttributeIds = null)
        {
            throw new NotImplementedException();
        }

        public void GetGiftCardAttribute(string attributesXml, out string recipientName, out string recipientEmail, out string senderName, out string senderEmail, out string giftCardMessage)
        {
            throw new NotImplementedException();
        }

        public bool? IsConditionMet(ProductAttributeMapping pam, string selectedAttributesXml)
        {
            throw new NotImplementedException();
        }

        public IList<ProductAttributeMapping> ParseProductAttributeMappings(string attributesXml)
        {
            throw new NotImplementedException();
        }

        public IList<ProductAttributeValue> ParseProductAttributeValues(string attributesXml, int productAttributeMappingId = 0)
        {
            throw new NotImplementedException();
        }

        public IList<string> ParseValues(string attributesXml, int productAttributeMappingId)
        {
            throw new NotImplementedException();
        }

        public string RemoveProductAttribute(string attributesXml, ProductAttributeMapping productAttributeMapping)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
