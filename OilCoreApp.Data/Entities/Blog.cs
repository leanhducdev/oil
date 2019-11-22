using OilCoreApp.Data.Enums;
using OilCoreApp.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OilCoreApp.Data.Entities
{
    [Table("Blogs")]
    public class Blog: DomainEntity<int>
    {
        public string Name { get; set; }

        public string Seo { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public string Image { get; set; }

        public Status Status { get; set; }
    }
}
