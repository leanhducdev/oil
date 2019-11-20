using OilCoreApp.Data.Enums;
using OilCoreApp.Data.Interfaces;
using OilCoreApp.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OilCoreApp.Data.Entities
{
    [Table("Feedbacks")]
    public class Feedback : DomainEntity<string>, ISwitchable, IDateTracking
    {
        [StringLength(250)]
        [Required]
        public string Name { get; set; }
        [StringLength(250)]
        public string Email { get; set; }
        [StringLength(500)]
        public string Message { get; set; }
        public Status Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime Modified { get; set; }
    }
}
