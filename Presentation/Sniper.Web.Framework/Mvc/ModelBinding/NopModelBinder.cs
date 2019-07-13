using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Web.Framework.Mvc.ModelBinding
{
    public class NopModelBinder : ComplexTypeModelBinder
    {
        public NopModelBinder(IDictionary<ModelMetadata, IModelBinder> propertyBinders, ILoggerFactory loggerFactory)
    : base(propertyBinders, loggerFactory)
        {
        }
    }
}
