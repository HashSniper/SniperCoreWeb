using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Sniper.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sniper.Web.Framework.Mvc.ModelBinding
{
    public class NopMetadataProvider : IDisplayMetadataProvider
    {

        public void CreateDisplayMetadata(DisplayMetadataProviderContext context)
        {
            var additionalValues = context.Attributes.OfType<IModelAttribute>().ToList();

            //and try add them as additional values of metadata
            foreach (var additionalValue in additionalValues)
            {
                if (context.DisplayMetadata.AdditionalValues.ContainsKey(additionalValue.Name))
                    throw new NopException("There is already an attribute with the name '{0}' on this model", additionalValue.Name);

                context.DisplayMetadata.AdditionalValues.Add(additionalValue.Name, additionalValue);
            }
        }
    }
}
