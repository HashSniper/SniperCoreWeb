using System;
using System.Collections.Generic;
using System.Text;
using Sniper.Core;
using Sniper.Core.Data;
using Sniper.Core.Domain.Common;
using Sniper.Services.Events;

namespace Sniper.Services.Common
{
    /// <summary>
    /// 搜索术语服务
    /// </summary>
    public partial class SearchTermService : ISearchTermService
    {
        #region Fields

        private readonly IEventPublisher _eventPublisher;
        private readonly IRepository<SearchTerm> _searchTermRepository;

        #endregion

        #region Ctor

        public SearchTermService(IEventPublisher eventPublisher,
            IRepository<SearchTerm> searchTermRepository)
        {
            _eventPublisher = eventPublisher;
            _searchTermRepository = searchTermRepository;
        }

        #endregion

        #region Methods
        public void DeleteSearchTerm(SearchTerm searchTerm)
        {
            throw new NotImplementedException();
        }

        public SearchTerm GetSearchTermById(int searchTermId)
        {
            throw new NotImplementedException();
        }

        public SearchTerm GetSearchTermByKeyword(string keyword, int storeId)
        {
            throw new NotImplementedException();
        }

        public IPagedList<SearchTermReportLine> GetStats(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            throw new NotImplementedException();
        }

        public void InsertSearchTerm(SearchTerm searchTerm)
        {
            throw new NotImplementedException();
        }

        public void UpdateSearchTerm(SearchTerm searchTerm)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
