using Microsoft.AspNetCore.Identity;
using OilCoreApp.Data.Enums;
using OilCoreApp.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OilCoreApp.Data.Entities
{
    [Table("AppUsers")]
    public class AppUser : IdentityUser<Guid>, ISwitchable, IDateTracking
    {
        public string FullName { get; set; }

        public DateTime BirthDay { get; set; }

        public decimal Balance { get; set; }

        public string Avata { get; set; }
        public Status Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime Modified { get; set; }
    }
}
