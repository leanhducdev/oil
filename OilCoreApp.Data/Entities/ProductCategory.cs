using OilCoreApp.Data.Enums;
using OilCoreApp.Data.Interfaces;
using OilCoreApp.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;

namespace OilCoreApp.Data.Entities
{
    public class ProductCategory : DomainEntity<int>, IHasSeoMetaData, ISwitchable, ISortable, IDateTracking
    {

        public ProductCategory()
        {
            Products = new List<Product>();
        }

       
        public ProductCategory(string name,string description, int? parentId, int? homeOrder,string image, bool? homeFlag,
            int sortOrder, Status status, string seoPageTitle, string seoAlias, string seoDescription, string seoKeyword)
        {
            Name = name;
            Description = description;
            ParentId = parentId;
            HomeOrder = homeOrder;
            Image = image;
            HomeFlag = homeFlag;
            SortOrder = sortOrder;
            Status = status;
            SeoPageTittle = seoPageTitle;
            SeoAlias = seoAlias;
            SeoDescriptions = seoDescription;
            SeoKeywords = seoKeyword;
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public int? ParentId { get; set; }

        public int? HomeOrder { get; set; }

        public string Image { get; set; }

        public bool? HomeFlag { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime Modified { get; set; }
        public int SortOrder { get; set; }
        public Status Status { get; set; }
        public string SeoPageTittle { get; set; }
        public string SeoAlias { get; set; }
        public string SeoKeywords { get; set; }
        public string SeoDescriptions { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}