using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sniper.Core;
using Sniper.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Data
{
    public partial class NopEntityTypeConfiguration<TEntity> : IMappingConfiguration, IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        #region Utilties

        protected virtual void PostConfigure(EntityTypeBuilder<TEntity> builder)
        {
        }

        #endregion

        #region Methods
        /// <summary>
        /// 配置实体
        /// </summary>
        /// <param name="builder"></param>
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            //add custom configuration
            PostConfigure(builder);
        }

        /// <summary>
        /// 应用此映射配置
        /// </summary>
        /// <param name="modelBuilder"></param>
        public virtual void ApplyConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(this);
        }
        #endregion
    }
}
