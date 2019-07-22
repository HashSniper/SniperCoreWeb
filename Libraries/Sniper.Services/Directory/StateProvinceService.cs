using System;
using System.Collections.Generic;
using System.Text;
using Sniper.Core.Caching;
using Sniper.Core.Data;
using Sniper.Core.Domain.Directory;
using Sniper.Services.Events;
using Sniper.Services.Localization;

namespace Sniper.Services.Directory
{
    public partial class StateProvinceService : IStateProvinceService
    {
        #region Fields

        private readonly ICacheManager _cacheManager;
        private readonly IEventPublisher _eventPublisher;
        private readonly ILocalizationService _localizationService;
        private readonly IRepository<StateProvince> _stateProvinceRepository;

        #endregion

        #region Ctor

        public StateProvinceService(ICacheManager cacheManager,
            IEventPublisher eventPublisher,
            ILocalizationService localizationService,
            IRepository<StateProvince> stateProvinceRepository)
        {
            _cacheManager = cacheManager;
            _eventPublisher = eventPublisher;
            _localizationService = localizationService;
            _stateProvinceRepository = stateProvinceRepository;
        }

        #endregion

        #region Methods
        public void DeleteStateProvince(StateProvince stateProvince)
        {
            throw new NotImplementedException();
        }

        public StateProvince GetStateProvinceByAbbreviation(string abbreviation, int? countryId = null)
        {
            throw new NotImplementedException();
        }

        public StateProvince GetStateProvinceById(int stateProvinceId)
        {
            throw new NotImplementedException();
        }

        public IList<StateProvince> GetStateProvinces(bool showHidden = false)
        {
            throw new NotImplementedException();
        }

        public IList<StateProvince> GetStateProvincesByCountryId(int countryId, int languageId = 0, bool showHidden = false)
        {
            throw new NotImplementedException();
        }

        public void InsertStateProvince(StateProvince stateProvince)
        {
            throw new NotImplementedException();
        }

        public void UpdateStateProvince(StateProvince stateProvince)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
