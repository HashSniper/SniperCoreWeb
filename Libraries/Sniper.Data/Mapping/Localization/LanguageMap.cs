using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sniper.Core.Domain.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Data.Mapping.Localization
{
    public partial class LanguageMap : NopEntityTypeConfiguration<Language>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.ToTable(nameof(Language));
            builder.HasKey(language => language.Id);

            builder.Property(language => language.Name).HasMaxLength(100).IsRequired();
            builder.Property(language => language.LanguageCulture).HasMaxLength(20).IsRequired();
            builder.Property(language => language.UniqueSeoCode).HasMaxLength(2);
            builder.Property(language => language.FlagImageFileName).HasMaxLength(50);

            base.Configure(builder);
        }

        #endregion
    }
}
