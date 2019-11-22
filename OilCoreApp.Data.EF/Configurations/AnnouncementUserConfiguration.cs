using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OilCoreApp.Data.EF.Extensions;
using OilCoreApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OilCoreApp.Data.EF.Configurations
{
    public class AnnouncementUserConfiguration : DbEntityConfiguration<AnnouncementUser>
    {
        public override void Configure(EntityTypeBuilder<AnnouncementUser> entity)
        {
            entity.Property(c => c.AnnouncementId).HasMaxLength(50).IsRequired().HasColumnType("varchar(50)");
        }
    }
}
