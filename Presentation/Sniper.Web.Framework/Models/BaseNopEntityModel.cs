using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Web.Framework.Models
{
    public partial class BaseNopEntityModel : BaseNopModel
    {
        /// <summary>
        /// Gets or sets model identifier
        /// </summary>
        public virtual int Id { get; set; }
    }
}
