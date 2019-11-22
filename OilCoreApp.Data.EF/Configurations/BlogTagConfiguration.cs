using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OilCoreApp.Data.EF.Extensions;
using OilCoreApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OilCoreApp.Data.EF.Configurations
{
    public class BlogTagConfiguration : DbEntityConfiguration<BlogTag>
    {
        public override void Configure(EntityTypeBuilder<BlogTag> entity)
        {
            entity.Property(c => c.TagId).HasMaxLength(50).IsRequired().HasColumnType("varchar(50)");
        }
    }
}
