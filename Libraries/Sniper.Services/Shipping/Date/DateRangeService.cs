using System;
using System.Collections.Generic;
using System.Text;
using Sniper.Core.Data;
using Sniper.Core.Domain.Shipping;
using Sniper.Services.Events;

namespace Sniper.Services.Shipping.Date
{
    public partial class DateRangeService : IDateRangeService
    {
        #region Fields

        private readonly IEventPublisher _eventPublisher;
        private readonly IRepository<DeliveryDate> _deliveryDateRepository;
        private readonly IRepository<ProductAvailabilityRange> _productAvailabilityRangeRepository;

        #endregion

        #region Ctor

        public DateRangeService(IEventPublisher eventPublisher,
            IRepository<DeliveryDate> deliveryDateRepository,
            IRepository<ProductAvailabilityRange> productAvailabilityRangeRepository)
        {
            _eventPublisher = eventPublisher;
            _deliveryDateRepository = deliveryDateRepository;
            _productAvailabilityRangeRepository = productAvailabilityRangeRepository;
        }

        #endregion

        #region Methods
        public void DeleteDeliveryDate(DeliveryDate deliveryDate)
        {
            throw new NotImplementedException();
        }

        public void DeleteProductAvailabilityRange(ProductAvailabilityRange productAvailabilityRange)
        {
            throw new NotImplementedException();
        }

        public IList<DeliveryDate> GetAllDeliveryDates()
        {
            throw new NotImplementedException();
        }

        public IList<ProductAvailabilityRange> GetAllProductAvailabilityRanges()
        {
            throw new NotImplementedException();
        }

        public DeliveryDate GetDeliveryDateById(int deliveryDateId)
        {
            throw new NotImplementedException();
        }

        public ProductAvailabilityRange GetProductAvailabilityRangeById(int productAvailabilityRangeId)
        {
            throw new NotImplementedException();
        }

        public void InsertDeliveryDate(DeliveryDate deliveryDate)
        {
            throw new NotImplementedException();
        }

        public void InsertProductAvailabilityRange(ProductAvailabilityRange productAvailabilityRange)
        {
            throw new NotImplementedException();
        }

        public void UpdateDeliveryDate(DeliveryDate deliveryDate)
        {
            throw new NotImplementedException();
        }

        public void UpdateProductAvailabilityRange(ProductAvailabilityRange productAvailabilityRange)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
