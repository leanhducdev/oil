using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OilCoreApp.Data.EF.Extensions;
using OilCoreApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OilCoreApp.Data.EF.Configurations
{
    public class FunctionConfiguration : DbEntityConfiguration<Functions>
    {
        public override void Configure(EntityTypeBuilder<Functions> entity)
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).IsRequired().HasColumnType("varchar(128");
        }
    }
}
