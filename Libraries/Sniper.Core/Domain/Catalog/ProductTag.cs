using Sniper.Core.Domain.Localization;
using Sniper.Core.Domain.Seo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Catalog
{
    public partial class ProductTag : BaseEntity, ILocalizedEntity, ISlugSupported
    {
        private ICollection<ProductProductTagMapping> _productProductTagMappings;

        public string Name { get; set; }

        public virtual ICollection<ProductProductTagMapping> ProductProductTagMappings
        {
            get => _productProductTagMappings ?? (_productProductTagMappings = new List<ProductProductTagMapping>());
            protected set => _productProductTagMappings = value;
        }
    }
}
