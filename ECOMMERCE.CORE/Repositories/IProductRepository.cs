using ECOMMERCE.CORE.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECOMMERCE.CORE.Repositories
{
    public interface IProductRepository : IRepository<Product, int>
    {
        List<Product> GetAllWithBrand();

        List<Product> GetAllWithBrandByCategoryCode(string categoryCode);

        List<Product> GetAllWithBrandBySubCategoryCode(string categoryCode, string subCategoryCode);

        List<Product> GetAllWithBrandByProductType(string categoryCode, string subCategoryCode, string productType);

        List<Product> GetAllWithBrandByProductType(string categoryCode, string subCategoryCode, string productType, int pageNumber, int itemsPerPage);

        Product GetByIdWithDetails(int productId);

        /// <summary>
        /// Bütün ürünleri sayfalama kriterlerine göre döndürür.
        /// </summary>
        /// <param name="pageNumber">Sayfa Numarası</param>
        /// <param name="itemsPerPage">Sayfa Başı Kayıt Sayısı</param>
        /// <returns></returns>
        List<Product> GetAllWithBrand(int pageNumber, int itemsPerPage);

        /// <summary>
        /// Ürünlerin toplam sayısını döndürür.
        /// </summary>
        /// <returns></returns>
        int Count();

        /// <summary>
        /// Ürünlerin toplam sayısını döndürür.
        /// </summary>
        /// <returns></returns>
        int Count(string categoryCode, string subCategoryCode, string productTypeCode);
    }
}
