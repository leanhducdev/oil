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
    [Table("Functions")]
    public class Functions : DomainEntity<string>, ISwitchable, ISortable
    {

        public Functions()
        {

        }

        public Functions(string name, string urls, string parentId, string iconCss, int sortOder, Status status)
        {
            this.Name = name;
            this.Urls = urls;
            this.ParentId = parentId;
            this.IconCss = iconCss;
            this.SortOrder = sortOder;
            this.Status = Status.Active;
        }
        [StringLength(128)]
        [Required]
        public string Name { get; set; }
        [StringLength(250)]
        [Required]
        public string Urls { get; set; }
        [StringLength(128)]
        public string ParentId { get; set; }

        public string IconCss { get; set; }

        public Status Status { get; set; }
        public int SortOrder { get; set; }
    }
}
