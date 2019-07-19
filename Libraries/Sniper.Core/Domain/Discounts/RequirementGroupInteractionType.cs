using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Discounts
{
    public enum RequirementGroupInteractionType
    {
        /// <summary>
        /// All requirements within the group must be met
        /// </summary>
        And = 0,

        /// <summary>
        /// At least one of the requirements within the group must be met 
        /// </summary>
        Or = 2
    }
}
