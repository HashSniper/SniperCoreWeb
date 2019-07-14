using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sniper.Core.Domain.Tasks;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Data.Mapping.Tasks
{
    public partial class ScheduleTaskMap : NopEntityTypeConfiguration<ScheduleTask>
    {
        public override void Configure(EntityTypeBuilder<ScheduleTask> builder)
        {
            builder.ToTable(nameof(ScheduleTask));
            builder.HasKey(task => task.Id);

            builder.Property(task => task.Name).IsRequired();
            builder.Property(task => task.Type).IsRequired();

            base.Configure(builder);
        }
    }
}
