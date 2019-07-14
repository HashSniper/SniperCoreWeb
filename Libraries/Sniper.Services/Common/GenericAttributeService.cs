using System;
using System.Collections.Generic;
using System.Text;
using Sniper.Core;
using Sniper.Core.Domain.Common;

namespace Sniper.Services.Common
{
    public partial class GenericAttributeService : IGenericAttributeService
    {
        public void DeleteAttribute(GenericAttribute attribute)
        {
            throw new NotImplementedException();
        }

        public void DeleteAttributes(IList<GenericAttribute> attributes)
        {
            throw new NotImplementedException();
        }

        public TPropType GetAttribute<TPropType>(BaseEntity entity, string key, int storeId = 0, TPropType defaultValue = default)
        {
            throw new NotImplementedException();
        }

        public GenericAttribute GetAttributeById(int attributeId)
        {
            throw new NotImplementedException();
        }

        public IList<GenericAttribute> GetAttributesForEntity(int entityId, string keyGroup)
        {
            throw new NotImplementedException();
        }

        public void InsertAttribute(GenericAttribute attribute)
        {
            throw new NotImplementedException();
        }

        public void SaveAttribute<TPropType>(BaseEntity entity, string key, TPropType value, int storeId = 0)
        {
            throw new NotImplementedException();
        }

        public void UpdateAttribute(GenericAttribute attribute)
        {
            throw new NotImplementedException();
        }
    }
}
