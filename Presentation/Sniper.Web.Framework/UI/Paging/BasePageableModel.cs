using Sniper.Web.Framework.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Web.Framework.UI.Paging
{
    /// <summary>
    /// 可分页模型的基类
    /// </summary>
    public abstract class BasePageableModel : BaseNopModel, IPageableModel
    {
        #region Properties
        public int PageIndex => throw new NotImplementedException();

        public int PageNumber => throw new NotImplementedException();

        public int PageSize => throw new NotImplementedException();

        public int TotalItems => throw new NotImplementedException();

        public int TotalPages => throw new NotImplementedException();

        public int FirstItem => throw new NotImplementedException();

        public int LastItem => throw new NotImplementedException();

        public bool HasPreviousPage => throw new NotImplementedException();

        public bool HasNextPage => throw new NotImplementedException();
        #endregion
    }
}
