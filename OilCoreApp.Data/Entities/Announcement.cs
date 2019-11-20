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

    [Table("Announcements")]
    public class Announcement : DomainEntity<string>, ISwitchable, IDateTracking
    {
        public Announcement()
        {
            AnnouncementUsers = new List<AnnouncementUser>();
        }
        [StringLength(250)]
        [Required]
        public string Tittle { get; set; }
        [StringLength(250)]
        public string Content { get; set; }
        [StringLength(450)]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual AppUser AppUser { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime Modified { get; set; }

        public Status Status { get; set; }

        public virtual ICollection<AnnouncementUser> AnnouncementUsers { get; set; }
    }
}
