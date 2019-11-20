using AutoMapper;
using AutoMapper.QueryableExtensions;
using OilCoreApp.Applications.Interfaces;
using OilCoreApp.Applications.ViewModels.Product;
using OilCoreApp.Data.Entities;
using OilCoreApp.Data.Enums;
using OilCoreApp.Data.IRepositories;
using OilCoreApp.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OilCoreApp.Applications.Implementation
{
    public class ProductCategoryService : IProductCategoryService
    {
        private IProductCategoryRepository _productCategoryRepository;
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;


        public ProductCategoryService(IProductCategoryRepository productCategoryRepository,IUnitOfWork unitOfWork)
        {
            _productCategoryRepository = productCategoryRepository;
            _unitOfWork = unitOfWork;
        }


        public ProductCategoryViewModel Add(ProductCategoryViewModel productCategoryVm)
        {
            var productCategory = Mapper.Map<ProductCategoryViewModel, ProductCategory>(productCategoryVm);
            _productCategoryRepository.Add(productCategory);
            return productCategoryVm;
        }

        public void Delete(int id)
        {
            _productCategoryRepository.Remove(id);
        }

        public List<ProductCategoryViewModel> GetAll()
        {
            return _productCategoryRepository.FinAll().OrderBy(x => x.ParentId).ProjectTo<ProductCategoryViewModel>().ToList();
        }

        public List<ProductCategoryViewModel> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
            {
                return _productCategoryRepository.FinAll(x => x.Name.Contains(keyword) || x.Description.Contains(keyword)).OrderBy(x => x.ParentId).ProjectTo<ProductCategoryViewModel>().ToList();
            }
            else
            {
                return _productCategoryRepository.FinAll().OrderBy(x => x.ParentId).ProjectTo<ProductCategoryViewModel>().ToList();
            }
        }

        public ProductCategoryViewModel GetById(int id)
        {
            return _mapper.Map<ProductCategory, ProductCategoryViewModel>(_productCategoryRepository.FindById(id));
        }

        public List<ProductCategoryViewModel> GetByParentId(int parentId)
        {
            return _productCategoryRepository.FinAll(x => x.Status == Status.Active && x.ParentId == parentId).ProjectTo<ProductCategoryViewModel>().ToList();
        }

        public List<ProductCategoryViewModel> GetHomeCategories(int top)
        {
            var query = _productCategoryRepository.FinAll(
                x => x.HomeFlag == true,
                c => c.Products).OrderBy(x => x.HomeOrder).Take(top).ProjectTo<ProductCategoryViewModel>();
            var categories = query.ToList();
            foreach (var category in categories)
            {
                /*category.Products = _productCategoryRepository.FinAll(x => x.HomeFlag == true && x.CategoryId == category.Id)
                    .OrderByDescending(x => x.DateCreate).Take(5)
                    .ProjectTo<ProductCategoryViewModel>().ToList();*/
            }
            return categories;
        }

        public void ReOder(int sourceId, int tagetId)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(ProductCategoryViewModel productCategoryVm)
        {
            throw new NotImplementedException();
        }

        public void UpdateParentId(int sourceId, int targetId, Dictionary<int, int> items)
        {
            throw new NotImplementedException();
        }
    }
}
