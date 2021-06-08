using ECOMMERCE.CORE.Entities;
using ECOMMERCE.CORE.Models;
using ECOMMERCE.CORE.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECOMMERCE.DATA.Repositories
{
    public class ProductRepository : RepositoryBase<Product, int>, IProductRepository
    {
        public ProductRepository(DbContext dbDataContext) : base(dbDataContext)
        {

        }

        public int Count()
        {
            return _dbDataContext.Products.Count();
        }

        public int Count(FilterModel filterModel, string categoryCode, string subCategoryCode, string productTypeCode)
        {
            var products = _dbDataContext.Products
                .Include(x => x.BrandModel)
                .Include(x => x.BrandModel.ProductPropertyValues)
                .Include(x => x.BrandModel.Brand)
                .Include(x => x.BrandModel.ProductType)
                .Include(x => x.BrandModel.ProductType.SubCategory)
                .Include(x => x.BrandModel.ProductType.SubCategory.Category)
                .Include(x => x.BrandModel.ProductType.ProductProperties).ToList();

            if (!string.IsNullOrEmpty(categoryCode))
            {
                products = products.Where(x => x.BrandModel.ProductType.SubCategory.Category.Code == categoryCode).ToList();
            }
            if (!string.IsNullOrEmpty(subCategoryCode))
            {
                products = products.Where(x => x.BrandModel.ProductType.SubCategory.Code == subCategoryCode).ToList();
            }
            if (!string.IsNullOrEmpty(productTypeCode))
            {
                products = products.Where(x => x.BrandModel.ProductType.Code == productTypeCode).ToList();
            }
            if (filterModel != null)
            {
                if (filterModel.BrandIdList != null && filterModel.BrandIdList.Any())
                {
                    products = products.Where(x => filterModel.BrandIdList.Contains(x.BrandModel.Brand.Id)).ToList();
                }
                if (filterModel.PriceMinValue != null && filterModel.PriceMaxValue != null)
                {
                    products = products.Where(x => x.Price >= filterModel.PriceMinValue && x.Price <= filterModel.PriceMaxValue).ToList();
                }
                if (filterModel.ProductProperties != null && filterModel.ProductProperties.Any())
                {
                    List<Product> productFilter = new List<Product>();
                    foreach (var productProperty in filterModel.ProductProperties)
                    {
                        productFilter.AddRange(products.Where(x => x.BrandModel.ProductPropertyValues.Any(y => y.ProductPropertyId == productProperty.Key && y.Value == productProperty.Value)));
                    }
                    products = productFilter;
                }
            }

            return products.Count();
        }

        public List<Product> GetAllWithBrand(int pageNumber, int itemsPerPage)
        {
            var skip = (pageNumber - 1) * itemsPerPage;
            return _dbDataContext.Products
                .Skip(skip)
                .Take(itemsPerPage)
                .Include(x => x.BrandModel)
                .Include(x => x.BrandModel.Brand)
                .Include(x => x.BrandModel.ProductType)
                .ToList();
        }

        public List<Product> GetAllWithBrand()
        {
            return _dbDataContext.Products
                .Include(x => x.BrandModel)
                .Include(x => x.BrandModel.Brand)
                .Include(x => x.BrandModel.ProductType).ToList();
        }

        public List<Product> GetAllWithBrandByCategoryCode(string categoryCode)
        {
            List<Product> products = _dbDataContext.Products
                .Include(x => x.BrandModel)
                .Include(x => x.BrandModel.ProductPropertyValues)
                .Include(x => x.BrandModel.Brand)
                .Include(x => x.BrandModel.ProductType)
                .Include(x => x.BrandModel.ProductType.SubCategory)
                .Include(x => x.BrandModel.ProductType.SubCategory.Category)
                .Include(x => x.BrandModel.ProductType.ProductProperties)
                .Where(x => x.BrandModel.ProductType.SubCategory.Category.Code == categoryCode).ToList();

            return products;
        }

        public List<Product> GetAllWithBrandByProductType(string categoryCode, string subCategoryCode, string productType)
        {
            var products = _dbDataContext.Products
                .Include(x => x.BrandModel)
                .Include(x => x.BrandModel.ProductPropertyValues)
                .Include(x => x.BrandModel.Brand)
                .Include(x => x.BrandModel.ProductType)
                .Include(x => x.BrandModel.ProductType.SubCategory)
                .Include(x => x.BrandModel.ProductType.SubCategory.Category)
                .Include(x => x.BrandModel.ProductType.ProductProperties)
            .Where(x => x.BrandModel.ProductType.SubCategory.Category.Code == categoryCode
            && x.BrandModel.ProductType.SubCategory.Code == subCategoryCode
            && x.BrandModel.ProductType.Code == productType).ToList();

            return products;

        }
        public List<Product> GetAllWithBrandByProductType(FilterModel filterModel, string categoryCode, string subCategoryCode, string productType, int pageNumber, int itemsPerPage)
        {
            var products = _dbDataContext.Products
                .Include(x => x.BrandModel)
                .Include(x => x.BrandModel.ProductPropertyValues)
                .Include(x => x.BrandModel.Brand)
                .Include(x => x.BrandModel.ProductType)
                .Include(x => x.BrandModel.ProductType.SubCategory)
                .Include(x => x.BrandModel.ProductType.SubCategory.Category)
                .Include(x => x.BrandModel.ProductType.ProductProperties).ToList();

            if (!string.IsNullOrEmpty(categoryCode))
            {
                products = products.Where(x => x.BrandModel.ProductType.SubCategory.Category.Code == categoryCode).ToList();
            }
            if (!string.IsNullOrEmpty(subCategoryCode))
            {
                products = products.Where(x => x.BrandModel.ProductType.SubCategory.Code == subCategoryCode).ToList();
            }
            if (!string.IsNullOrEmpty(productType))
            {
                products = products.Where(x => x.BrandModel.ProductType.Code == productType).ToList();
            }
            if (filterModel != null)
            {
                if (filterModel.BrandIdList != null && filterModel.BrandIdList.Any())
                {
                    products = products.Where(x => filterModel.BrandIdList.Contains(x.BrandModel.Brand.Id)).ToList();
                }
                if (filterModel.PriceMinValue != null && filterModel.PriceMaxValue != null)
                {
                    products = products.Where(x => x.Price >= filterModel.PriceMinValue && x.Price <= filterModel.PriceMaxValue).ToList();
                }
                if (filterModel.ProductProperties != null && filterModel.ProductProperties.Any())
                {
                    List<Product> productFilter = new List<Product>();
                    foreach (var productProperty in filterModel.ProductProperties)
                    {
                        productFilter.AddRange(products.Where(x => x.BrandModel.ProductPropertyValues.Any(y => y.ProductPropertyId == productProperty.Key && y.Value == productProperty.Value)));
                    }
                    products = productFilter;
                }
            }

            var skip = (pageNumber - 1) * itemsPerPage;
            products = products.Skip(skip).Take(itemsPerPage).ToList();

            return products.ToList();
        }

        public List<Product> GetAllWithBrandBySubCategoryCode(string categoryCode, string subCategoryCode)
        {
            List<Product> products = _dbDataContext.Products
                .Include(x => x.BrandModel)
                .Include(x => x.BrandModel.ProductPropertyValues)
                .Include(x => x.BrandModel.Brand)
                .Include(x => x.BrandModel.ProductType)
                .Include(x => x.BrandModel.ProductType.SubCategory)
                .Include(x => x.BrandModel.ProductType.SubCategory.Category)
                .Include(x => x.BrandModel.ProductType.ProductProperties)
                .Where(x => x.BrandModel.ProductType.SubCategory.Category.Code == categoryCode && x.BrandModel.ProductType.SubCategory.Code == subCategoryCode).ToList();

            return products;
        }

        public Product GetByIdWithDetails(int productId)
        {
            return _dbDataContext.Products
                 .Include(x => x.BrandModel)
                 .Include(x => x.BrandModel.ProductPropertyValues)
                 .Include(x => x.BrandModel.Brand)
                 .Include(x => x.BrandModel.ProductType)
                 .Include(x => x.BrandModel.ProductType.SubCategory)
                 .Include(x => x.BrandModel.ProductType.SubCategory.Category)
                 .Include(x => x.BrandModel.ProductType.ProductProperties)
                 .Include(x => x.Comments).ThenInclude(y => y.Customer)
                 .FirstOrDefault(x => x.Id == productId);
        }
    }
}
