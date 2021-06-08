using ECOMMERCE.CORE.Entities;
using ECOMMERCE.CORE.Models;
using ECOMMERCE.CORE.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECOMMERCE.CORE.BusinessServices.Implementation
{
    public class ProductBusinessService : IProductBusinessService
    {
        private readonly IProductRepository _productRepository;
        private readonly ISubCategoriesRepository _subCategoriesRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ProductBusinessService(IProductRepository productRepository, ISubCategoriesRepository subCategoriesRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _subCategoriesRepository = subCategoriesRepository;
            _unitOfWork = unitOfWork;
        }

        public int Count()
        {
            return _productRepository.Count();
        }

        public int Count(FilterModel filterModel, string categoryCode, string subCategoryCode, string productTypeCode)
        {
            return _productRepository.Count(filterModel, categoryCode, subCategoryCode, productTypeCode);
        }

        public void Delete(int productId)
        {
            Product product = GetById(productId);
            _productRepository.Delete(product);
            _unitOfWork.Complete();
        }

        public List<Product> GetAll()
        {
            return _productRepository.All();
        }

        public List<Product> GetAllWithBrand(int pageNumber, int itemsPerPage)
        {
            List<SubCategories> subCategories = _subCategoriesRepository.GetAllWithCategories();

            List<Product> products = _productRepository.GetAllWithBrand(pageNumber, itemsPerPage);
            foreach (var product in products)
            {
                product.BrandModel.ProductType.SubCategory = subCategories.Find(x => x.Id == product.BrandModel.ProductType.SubCategoryId);
            }
            return products;
        }

        public List<Product> GetAllWithBrand()
        {
            return _productRepository.GetAllWithBrand();
        }

        public List<Product> GetAllWithBrandByCategoryCode(string categoryCode)
        {
            return _productRepository.GetAllWithBrandByCategoryCode(categoryCode);
        }

        public List<Product> GetAllWithBrandByProductType(string categoryCode, string subCategoryCode, string productType)
        {
            return _productRepository.GetAllWithBrandByProductType(categoryCode, subCategoryCode, productType);
        }

        public List<Product> GetAllWithBrandByProductType(FilterModel filterModel, string categoryCode, string subCategoryCode, string productType, int pageNumber, int itemsPerPage)
        {
            return _productRepository.GetAllWithBrandByProductType(filterModel, categoryCode, subCategoryCode, productType, pageNumber, itemsPerPage);
        }

        public List<Product> GetAllWithBrandBySubCategoryCode(string categoryCode, string subCategoryCode)
        {
            return _productRepository.GetAllWithBrandBySubCategoryCode(categoryCode, subCategoryCode);
        }

        public Product GetById(int productId)
        {
            return _productRepository.FindById(productId);
        }

        public Product GetByIdWithDetails(int productId)
        {
            return _productRepository.GetByIdWithDetails(productId);
        }

        public void Save(Product product)
        {
            _productRepository.Add(product);
            _unitOfWork.Complete();
        }

        public void Update(Product product)
        {
            _productRepository.Update(product);
            _unitOfWork.Complete();
        }
    }
}
