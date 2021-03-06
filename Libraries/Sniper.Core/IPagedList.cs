﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core
{
    public interface IPagedList<T>:IList<T>
    {
        int PageIndex { get; set; }

        int PageSize { get; set; }

        int TotalCount { get; set; }

        int TotalPages { get; set; }

        bool HasPreviousPage { get; }

        bool HasNextPage { get; }
    }
}
