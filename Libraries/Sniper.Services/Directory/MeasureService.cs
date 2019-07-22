using System;
using System.Collections.Generic;
using System.Text;
using Sniper.Core.Caching;
using Sniper.Core.Data;
using Sniper.Core.Domain.Directory;
using Sniper.Services.Events;

namespace Sniper.Services.Directory
{
    public partial class MeasureService : IMeasureService
    {
        #region Fields

        private readonly ICacheManager _cacheManager;
        private readonly IEventPublisher _eventPublisher;
        private readonly IRepository<MeasureDimension> _measureDimensionRepository;
        private readonly IRepository<MeasureWeight> _measureWeightRepository;
        private readonly MeasureSettings _measureSettings;

        #endregion

        #region Ctor

        public MeasureService(ICacheManager cacheManager,
            IEventPublisher eventPublisher,
            IRepository<MeasureDimension> measureDimensionRepository,
            IRepository<MeasureWeight> measureWeightRepository,
            MeasureSettings measureSettings)
        {
            _cacheManager = cacheManager;
            _eventPublisher = eventPublisher;
            _measureDimensionRepository = measureDimensionRepository;
            _measureWeightRepository = measureWeightRepository;
            _measureSettings = measureSettings;
        }

        #endregion

        #region Methods
        public decimal ConvertDimension(decimal value, MeasureDimension sourceMeasureDimension, MeasureDimension targetMeasureDimension, bool round = true)
        {
            throw new NotImplementedException();
        }

        public decimal ConvertFromPrimaryMeasureDimension(decimal value, MeasureDimension targetMeasureDimension)
        {
            throw new NotImplementedException();
        }

        public decimal ConvertFromPrimaryMeasureWeight(decimal value, MeasureWeight targetMeasureWeight)
        {
            throw new NotImplementedException();
        }

        public decimal ConvertToPrimaryMeasureDimension(decimal value, MeasureDimension sourceMeasureDimension)
        {
            throw new NotImplementedException();
        }

        public decimal ConvertToPrimaryMeasureWeight(decimal value, MeasureWeight sourceMeasureWeight)
        {
            throw new NotImplementedException();
        }

        public decimal ConvertWeight(decimal value, MeasureWeight sourceMeasureWeight, MeasureWeight targetMeasureWeight, bool round = true)
        {
            throw new NotImplementedException();
        }

        public void DeleteMeasureDimension(MeasureDimension measureDimension)
        {
            throw new NotImplementedException();
        }

        public void DeleteMeasureWeight(MeasureWeight measureWeight)
        {
            throw new NotImplementedException();
        }

        public IList<MeasureDimension> GetAllMeasureDimensions()
        {
            throw new NotImplementedException();
        }

        public IList<MeasureWeight> GetAllMeasureWeights()
        {
            throw new NotImplementedException();
        }

        public MeasureDimension GetMeasureDimensionById(int measureDimensionId)
        {
            throw new NotImplementedException();
        }

        public MeasureDimension GetMeasureDimensionBySystemKeyword(string systemKeyword)
        {
            throw new NotImplementedException();
        }

        public MeasureWeight GetMeasureWeightById(int measureWeightId)
        {
            throw new NotImplementedException();
        }

        public MeasureWeight GetMeasureWeightBySystemKeyword(string systemKeyword)
        {
            throw new NotImplementedException();
        }

        public void InsertMeasureDimension(MeasureDimension measure)
        {
            throw new NotImplementedException();
        }

        public void InsertMeasureWeight(MeasureWeight measure)
        {
            throw new NotImplementedException();
        }

        public void UpdateMeasureDimension(MeasureDimension measure)
        {
            throw new NotImplementedException();
        }

        public void UpdateMeasureWeight(MeasureWeight measure)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
