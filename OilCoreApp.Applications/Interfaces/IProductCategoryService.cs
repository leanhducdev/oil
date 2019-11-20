using OilCoreApp.Applications.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace OilCoreApp.Applications.Interfaces
{
    public interface IProductCategoryService
    {
        ProductCategoryViewModel Add(ProductCategoryViewModel productCategoryVm);
        void Update(ProductCategoryViewModel productCategoryVm);
        void Delete(int id);
        List<ProductCategoryViewModel> GetAll();
        List<ProductCategoryViewModel> GetAll(string keyword);
        List<ProductCategoryViewModel> GetByParentId(int parentId);
        ProductCategoryViewModel GetById(int id);

        void UpdateParentId(int sourceId, int targetId, Dictionary<int, int> items);
        void ReOder(int sourceId, int tagetId);

        List<ProductCategoryViewModel> GetHomeCategories(int top);

        void Save();
    }
}
