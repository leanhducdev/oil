using OilCoreApp.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OilCoreApp.Data.Entities
{
    [Table("Slides")]
    public class Slide : DomainEntity<int>
    {
        [StringLength(250)]
        [Required]
        public string Name { get; set; }
        [StringLength(250)]
        public string Description { get; set; }
        [StringLength(250)]
        [Required]
        public string Image { get; set; }
        [StringLength(250)]
        public string Urls { get; set; }

        public int? DisplayOrder { get; set; }

        public bool Status { get; set; }

        public string Content { get; set; }
        [StringLength(25)]
        [Required]
        public string GroupAlias { get; set; }
    }
}
