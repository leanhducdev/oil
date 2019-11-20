using OilCoreApp.Data.Enums;
using OilCoreApp.Data.Interfaces;
using OilCoreApp.Infrastructure.SharedKernel;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OilCoreApp.Data.Entities
{
    [Table("Advertistments")]
    public class Advertistment : DomainEntity<int>, ISwitchable, ISortable, IDateTracking
    {
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [StringLength(255)]
        public string Image { get; set; }

        [StringLength(255)]
        public string Urls { get; set; }

        [StringLength(20)]
        public string PositionId { get; set; }

        [ForeignKey("PositionId")]
        public virtual AdvertistmentPosition AdvertistmentPosition { get; set; }

        public Status Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime Modified { get; set; }
        public int SortOrder { get; set; }
    }
}