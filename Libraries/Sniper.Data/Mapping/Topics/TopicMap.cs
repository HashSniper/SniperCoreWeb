using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sniper.Core.Domain.Topics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Data.Mapping.Topics
{
    public partial class TopicMap : NopEntityTypeConfiguration<Topic>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<Topic> builder)
        {
            builder.ToTable(nameof(Topic));
            builder.HasKey(topic => topic.Id);

            base.Configure(builder);
        }

        #endregion
    }
}
