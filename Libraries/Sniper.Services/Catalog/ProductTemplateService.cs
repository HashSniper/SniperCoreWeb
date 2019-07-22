using System;
using System.Collections.Generic;
using System.Text;
using Sniper.Core.Data;
using Sniper.Core.Domain.Catalog;
using Sniper.Services.Events;

namespace Sniper.Services.Catalog
{
    public partial class ProductTemplateService : IProductTemplateService
    {
        #region Fields

        private readonly IEventPublisher _eventPublisher;
        private readonly IRepository<ProductTemplate> _productTemplateRepository;

        #endregion

        #region Ctor

        public ProductTemplateService(IEventPublisher eventPublisher,
            IRepository<ProductTemplate> productTemplateRepository)
        {
            _eventPublisher = eventPublisher;
            _productTemplateRepository = productTemplateRepository;
        }

        #endregion

        #region Methods
        public void DeleteProductTemplate(ProductTemplate productTemplate)
        {
            throw new NotImplementedException();
        }

        public IList<ProductTemplate> GetAllProductTemplates()
        {
            throw new NotImplementedException();
        }

        public ProductTemplate GetProductTemplateById(int productTemplateId)
        {
            throw new NotImplementedException();
        }

        public void InsertProductTemplate(ProductTemplate productTemplate)
        {
            throw new NotImplementedException();
        }

        public void UpdateProductTemplate(ProductTemplate productTemplate)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
