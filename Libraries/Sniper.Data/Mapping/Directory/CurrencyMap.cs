﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sniper.Core.Domain.Directory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Data.Mapping.Directory
{
    public partial class CurrencyMap : NopEntityTypeConfiguration<Currency>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.ToTable(nameof(Currency));
            builder.HasKey(currency => currency.Id);

            builder.Property(currency => currency.Name).HasMaxLength(50).IsRequired();
            builder.Property(currency => currency.CurrencyCode).HasMaxLength(5).IsRequired();
            builder.Property(currency => currency.DisplayLocale).HasMaxLength(50);
            builder.Property(currency => currency.CustomFormatting).HasMaxLength(50);
            builder.Property(currency => currency.Rate).HasColumnType("decimal(18, 4)");

            builder.Ignore(currency => currency.RoundingType);

            base.Configure(builder);
        }

        #endregion
    }
}
