using System;
using System.Collections.Generic;
using System.Text;
using Sniper.Core.Caching;
using Sniper.Core.Data;
using Sniper.Core.Domain.Catalog;
using Sniper.Services.Events;

namespace Sniper.Services.Catalog
{
    public partial class ReviewTypeService : IReviewTypeService
    {
        #region Fields

        private readonly IEventPublisher _eventPublisher;
        private readonly IRepository<ProductReviewReviewTypeMapping> _productReviewReviewTypeMappingRepository;
        private readonly IRepository<ReviewType> _reviewTypeRepository;
        private readonly IStaticCacheManager _cacheManager;

        #endregion

        #region Ctor

        public ReviewTypeService(IEventPublisher eventPublisher,
            IRepository<ProductReviewReviewTypeMapping> productReviewReviewTypeMappingRepository,
            IRepository<ReviewType> reviewTypeRepository,
            IStaticCacheManager cacheManager)
        {
            _eventPublisher = eventPublisher;
            _productReviewReviewTypeMappingRepository = productReviewReviewTypeMappingRepository;
            _reviewTypeRepository = reviewTypeRepository;
            _cacheManager = cacheManager;
        }

        #endregion

        #region Methods
        public void DeleteReiewType(ReviewType reviewType)
        {
            throw new NotImplementedException();
        }

        public IList<ReviewType> GetAllReviewTypes()
        {
            throw new NotImplementedException();
        }

        public IList<ProductReviewReviewTypeMapping> GetProductReviewReviewTypeMappingsByProductReviewId(int productReviewId)
        {
            throw new NotImplementedException();
        }

        public ReviewType GetReviewTypeById(int reviewTypeId)
        {
            throw new NotImplementedException();
        }

        public void InsertReviewType(ReviewType reviewType)
        {
            throw new NotImplementedException();
        }

        public void UpdateReviewType(ReviewType reviewType)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
