using OilCoreApp.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace OilCoreApp.Applications.ViewModels.Product
{
    public class ProductCategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public int? ParentId { get; set; }

        public int? HomeOrder { get; set; }

        public string Image { get; set; }

        public bool HomeFlag { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime Modified { get; set; }
        public int SortOrder { get; set; }
        public Status Status { get; set; }
        public string SeoPageTittle { get; set; }
        public string SeoAlias { get; set; }
        public string SeoKeywords { get; set; }
        public string SeoDescriptions { get; set; }

        public virtual ICollection<ProductViewModel> Products { get; set; }
    }
}
