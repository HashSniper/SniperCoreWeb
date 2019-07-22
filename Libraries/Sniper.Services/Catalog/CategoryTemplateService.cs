using System;
using System.Collections.Generic;
using System.Text;
using Sniper.Core.Data;
using Sniper.Core.Domain.Catalog;
using Sniper.Services.Events;

namespace Sniper.Services.Catalog
{
    public partial class CategoryTemplateService : ICategoryTemplateService
    {
        #region Fields

        private readonly IEventPublisher _eventPublisher;
        private readonly IRepository<CategoryTemplate> _categoryTemplateRepository;

        #endregion

        #region Ctor

        public CategoryTemplateService(IEventPublisher eventPublisher,
            IRepository<CategoryTemplate> categoryTemplateRepository)
        {
            _eventPublisher = eventPublisher;
            _categoryTemplateRepository = categoryTemplateRepository;
        }

        #endregion

        #region Methods
        public void DeleteCategoryTemplate(CategoryTemplate categoryTemplate)
        {
            throw new NotImplementedException();
        }

        public IList<CategoryTemplate> GetAllCategoryTemplates()
        {
            throw new NotImplementedException();
        }

        public CategoryTemplate GetCategoryTemplateById(int categoryTemplateId)
        {
            throw new NotImplementedException();
        }

        public void InsertCategoryTemplate(CategoryTemplate categoryTemplate)
        {
            throw new NotImplementedException();
        }

        public void UpdateCategoryTemplate(CategoryTemplate categoryTemplate)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
