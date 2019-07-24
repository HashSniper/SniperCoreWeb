using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sniper.Core.Domain.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Data.Mapping.Security
{
    public partial class PermissionRecordCustomerRoleMap : NopEntityTypeConfiguration<PermissionRecordCustomerRoleMapping>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<PermissionRecordCustomerRoleMapping> builder)
        {
            builder.ToTable(NopMappingDefaults.PermissionRecordRoleTable);
            builder.HasKey(mapping => new { mapping.PermissionRecordId, mapping.CustomerRoleId });

            builder.Property(mapping => mapping.PermissionRecordId).HasColumnName("PermissionRecord_Id");
            builder.Property(mapping => mapping.CustomerRoleId).HasColumnName("CustomerRole_Id");

            builder.HasOne(mapping => mapping.CustomerRole)
                .WithMany(role => role.PermissionRecordCustomerRoleMappings)
                .HasForeignKey(mapping => mapping.CustomerRoleId)
                .IsRequired();

            builder.HasOne(mapping => mapping.PermissionRecord)
                .WithMany(record => record.PermissionRecordCustomerRoleMappings)
                .HasForeignKey(mapping => mapping.PermissionRecordId)
                .IsRequired();

            builder.Ignore(mapping => mapping.Id);

            base.Configure(builder);
        }

        #endregion
    }
}
