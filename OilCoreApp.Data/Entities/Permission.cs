using OilCoreApp.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OilCoreApp.Data.Entities
{
    [Table("Permissions")]
    public class Permission : DomainEntity<int>
    {
        [Required]
        public Guid RoleId { get; set; }
        [StringLength(128)]
        [Required]
        public string FunctionId { get; set; }

        public bool CanCreate { get; set; }

        public bool CanRead { get; set; }
        public bool CanUpdate { get; set; }
        public bool CanDelete { get; set; }

        [ForeignKey("RoleId")]
        public virtual AppRole AppRole { get; set; }
        [ForeignKey("FunctionId")]
        public virtual Functions Functions { get; set; }
    }
}
