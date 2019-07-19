using Sniper.Core;
using Sniper.Core.Caching;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Data.EntityExtensions
{
    public static class EntityExtensions
    {
        /// <summary>
        /// 获取未经代理的实体类型
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static Type GetUnproxiedEntityType(this BaseEntity entity)
        {
            if(entity==null)
                throw new ArgumentNullException(nameof(entity));

            Type type = null;

            if (entity is IEntityForCaching)
            {
                type = ((IEntityForCaching)entity).GetType().BaseType;
            }
            else if (entity.IsProxy())
            {
                type = entity.GetType().BaseType;
            }
            else
            {
                type = entity.GetType();
            }

            if(type==null)
                throw new Exception("Original entity type cannot be loaded");

            return type;
        }

        /// <summary>
        /// 检查实体是否是代理
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        private static bool IsProxy(this BaseEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var type = entity.GetType();

            return type.BaseType != null && type.BaseType.BaseType != null && type.BaseType.BaseType == typeof(BaseEntity);
        }

    }
}
