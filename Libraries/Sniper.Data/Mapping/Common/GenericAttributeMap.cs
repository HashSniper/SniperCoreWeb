﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sniper.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Data.Mapping.Common
{
    public partial class GenericAttributeMap : NopEntityTypeConfiguration<GenericAttribute>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<GenericAttribute> builder)
        {
            builder.ToTable(nameof(GenericAttribute));
            builder.HasKey(attribute => attribute.Id);

            builder.Property(attribute => attribute.KeyGroup).HasMaxLength(400).IsRequired();
            builder.Property(attribute => attribute.Key).HasMaxLength(400).IsRequired();
            builder.Property(attribute => attribute.Value).IsRequired();

            base.Configure(builder);
        }

        #endregion
    }
}