using System;
using System.Collections.Generic;
using System.Text;
using Sniper.Core.Data;
using Sniper.Core.Domain.Catalog;
using Sniper.Services.Events;

namespace Sniper.Services.Catalog
{
    public partial class ManufacturerTemplateService : IManufacturerTemplateService
    {
        #region Fields

        private readonly IEventPublisher _eventPublisher;
        private readonly IRepository<ManufacturerTemplate> _manufacturerTemplateRepository;

        #endregion

        #region Ctor

        public ManufacturerTemplateService(IEventPublisher eventPublisher,
            IRepository<ManufacturerTemplate> manufacturerTemplateRepository)
        {
            _eventPublisher = eventPublisher;
            _manufacturerTemplateRepository = manufacturerTemplateRepository;
        }

        #endregion

        #region Methods
        public void DeleteManufacturerTemplate(ManufacturerTemplate manufacturerTemplate)
        {
            throw new NotImplementedException();
        }

        public IList<ManufacturerTemplate> GetAllManufacturerTemplates()
        {
            throw new NotImplementedException();
        }

        public ManufacturerTemplate GetManufacturerTemplateById(int manufacturerTemplateId)
        {
            throw new NotImplementedException();
        }

        public void InsertManufacturerTemplate(ManufacturerTemplate manufacturerTemplate)
        {
            throw new NotImplementedException();
        }

        public void UpdateManufacturerTemplate(ManufacturerTemplate manufacturerTemplate)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
