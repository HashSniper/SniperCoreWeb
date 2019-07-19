using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sniper.Core.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Data.Mapping.Catalog
{
    /// <summary>
    /// 制造商映射配置
    /// </summary>
    public partial class ManufacturerMap : NopEntityTypeConfiguration<Manufacturer>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<Manufacturer> builder)
        {
            builder.ToTable(nameof(Manufacturer));
            builder.HasKey(manufacturer => manufacturer.Id);

            builder.Property(manufacturer => manufacturer.Name).HasMaxLength(400).IsRequired();
            builder.Property(manufacturer => manufacturer.MetaKeywords).HasMaxLength(400);
            builder.Property(manufacturer => manufacturer.MetaTitle).HasMaxLength(400);
            builder.Property(manufacturer => manufacturer.PriceRanges).HasMaxLength(400);
            builder.Property(manufacturer => manufacturer.PageSizeOptions).HasMaxLength(200);

            builder.Ignore(manufacturer => manufacturer.AppliedDiscounts);

            base.Configure(builder);
        }

        #endregion
    }
}
