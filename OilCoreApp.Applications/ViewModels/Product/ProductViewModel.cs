using OilCoreApp.Data.Entities;
using OilCoreApp.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OilCoreApp.Applications.ViewModels.Product
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [StringLength(255)]
        public string Image { get; set; }

        [Required]
        [DefaultValue(0)]
        public decimal Price { get; set; }

        public decimal? PromotionPrice { get; set; }


        [Required]
        public decimal OrignalPrice { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public string Content { get; set; }

        public bool? HomeFlag { get; set; }

        public bool HotFlag { get; set; }

        public int? ViewCount { get; set; }

        [StringLength(255)]
        public string Tags { get; set; }

        public string Unit { get; set; }

        
        public virtual ProductCategoryViewModel ProductCategory { get; set; }

        public string SeoPageTittle { get; set; }

        [StringLength(255)]
        public string SeoAlias { get; set; }
        [StringLength(255)]
        public string SeoKeywords { get; set; }
        [StringLength(255)]
        public string SeoDescriptions { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime Modified { get; set; }
        public Status Status { get; set; }
    }
}
