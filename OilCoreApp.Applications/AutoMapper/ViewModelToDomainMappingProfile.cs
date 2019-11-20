using AutoMapper;
using OilCoreApp.Applications.ViewModels.Product;
using OilCoreApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OilCoreApp.Applications.AutoMapper
{
    class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProductCategoryViewModel, ProductCategory>().ConstructUsing(c=> new ProductCategory(c.Name,c.Description,c.ParentId,c.HomeOrder,c.Image,c.HomeFlag,
                c.SortOrder,c.Status,c.SeoPageTittle,c.SeoDescriptions,c.SeoAlias,c.SeoKeywords));
        }
    }
}
