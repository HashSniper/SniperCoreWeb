﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Common
{
    public enum FulltextSearchMode
    {
        /// <summary>
        /// Exact match (using CONTAINS with prefix_term)
        /// </summary>
        ExactMatch = 0,

        /// <summary>
        /// Using CONTAINS and OR with prefix_term
        /// </summary>
        Or = 5,

        /// <summary>
        /// Using CONTAINS and AND with prefix_term
        /// </summary>
        And = 10
    }
}