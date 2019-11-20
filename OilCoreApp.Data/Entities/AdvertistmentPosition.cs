using OilCoreApp.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OilCoreApp.Data.Entities
{
    [Table("AdvertistmentPosition")]
    public class AdvertistmentPosition:DomainEntity<string>
    {
        public string Name { get; set; }

        public string PageId { get; set; }

        [ForeignKey("PageId")]
        public virtual AdvertistmentPage AdvertistmentPage { get; set; }
    }
}
