using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OilCoreApp.Data.EF.Extensions;
using OilCoreApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OilCoreApp.Data.EF.Configurations
{
    public class SystemConfigConfiguration : DbEntityConfiguration<SystemConfig>
    {
        public override void Configure(EntityTypeBuilder<SystemConfig> entity)
        {
            entity.Property(c => c.Id).HasMaxLength(255).IsRequired();
        }
    }
}
