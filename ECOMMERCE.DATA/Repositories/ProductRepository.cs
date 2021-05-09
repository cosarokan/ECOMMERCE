using ECOMMERCE.CORE.Entities;
using ECOMMERCE.CORE.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ECOMMERCE.DATA.Repositories
{
    public class ProductRepository : RepositoryBase<Product, int>, IProductRepository
    {
        public ProductRepository(DbContext dbDataContext) : base(dbDataContext)
        {

        }

        public List<Product> GetAllWithBrand()
        {
            return _dbDataContext.Products.Include(x => x.BrandModel).Include(x => x.BrandModel.Brand).ToList();
        }

        public List<Product> GetAllWithBrandByCategoryCode(string categoryCode)
        {
            List<Product> products = _dbDataContext.Products
                .Include(x => x.BrandModel)
                .Include(x => x.BrandModel.Brand)
                .Include(x=>x.BrandModel.ProductType)
                .Include(x=>x.BrandModel.ProductType.SubCategory)
                .Include(x=>x.BrandModel.ProductType.SubCategory.Category)
                .Where(x => x.BrandModel.ProductType.SubCategory.Category.Code == categoryCode).ToList();

            return products;
        }

        public List<Product> GetAllWithBrandByProductType(string categoryCode, string subCategoryCode, string productType)
        {
            List<Product> products = _dbDataContext.Products
                .Include(x => x.BrandModel)
                .Include(x => x.BrandModel.Brand)
                .Include(x => x.BrandModel.ProductType)
                .Include(x => x.BrandModel.ProductType.SubCategory)
                .Include(x => x.BrandModel.ProductType.SubCategory.Category)
                .Where(x => x.BrandModel.ProductType.SubCategory.Category.Code == categoryCode
                && x.BrandModel.ProductType.SubCategory.Code == subCategoryCode
                && x.BrandModel.ProductType.Code == productType).ToList();

            return products;
        }

        public List<Product> GetAllWithBrandBySubCategoryCode(string categoryCode, string subCategoryCode)
        {
            List<Product> products = _dbDataContext.Products
                .Include(x => x.BrandModel)
                .Include(x => x.BrandModel.Brand)
                .Include(x => x.BrandModel.ProductType)
                .Include(x => x.BrandModel.ProductType.SubCategory)
                .Include(x => x.BrandModel.ProductType.SubCategory.Category)
                .Where(x => x.BrandModel.ProductType.SubCategory.Category.Code == categoryCode && x.BrandModel.ProductType.SubCategory.Code == subCategoryCode).ToList();

            return products;
        }

        public Product GetByIdWithDetails(int productId)
        {
           return _dbDataContext.Products
                .Include(x => x.BrandModel)
                .Include(x => x.BrandModel.Brand)
                .Include(x => x.BrandModel.ProductType)
                .Include(x => x.BrandModel.ProductType.SubCategory)
                .Include(x => x.BrandModel.ProductType.SubCategory.Category)
                .FirstOrDefault(x => x.Id == productId);
        }
    }
}
