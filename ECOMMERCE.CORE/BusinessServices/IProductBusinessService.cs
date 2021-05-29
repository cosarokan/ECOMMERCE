using ECOMMERCE.CORE.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECOMMERCE.CORE.BusinessServices
{
    public interface IProductBusinessService
    {
        /// <summary>
        /// Ürün kaydetme işlemini yapar.
        /// </summary>
        /// <param name="product"></param>
        void Save(Product product);

        /// <summary>
        /// Ürün güncelleme işlemini yapar.
        /// </summary>
        /// <param name="product"></param>
        void Update(Product product);

        /// <summary>
        /// Ürün silme işlemini yapar.
        /// </summary>
        /// <param name="productId"></param>
        void Delete(int productId);

        /// <summary>
        /// Tüm Ödeme Tipi kayıtlarını döndürür.
        /// </summary>
        /// <returns></returns>
        List<Product> GetAll();

        /// <summary>
        /// Id'ye göre Ürün kaydını döndürür.
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Product GetById(int productId);

        /// <summary>
        /// Bütün ürünleri model bilgisiyle birlikte döndürür
        /// </summary>
        /// <returns></returns>
        List<Product> GetAllWithBrand();

        /// <summary>
        /// Kategori koduna göre bütün ürünleri model bilgisiyle birlikte döndürür
        /// </summary>
        /// <returns></returns>
        List<Product> GetAllWithBrandByCategoryCode(string categoryCode);

        /// <summary>
        /// Kategori ve alt kategori koduna göre bütün ürünleri model bilgisiyle birlikte döndürür
        /// </summary>
        /// <returns></returns>
        List<Product> GetAllWithBrandBySubCategoryCode(string categoryCode, string subCategoryCode);

        /// <summary>
        /// Kategori, alt kategori ve ürün tipi koduna göre bütün ürünleri model bilgisiyle birlikte döndürür
        /// </summary>
        /// <returns></returns>
        List<Product> GetAllWithBrandByProductType(string categoryCode, string subCategoryCode, string productType);

        /// <summary>
        /// Id'ye göre Ürünün bağlı olduğu kategori, alt kategori ve ürün tipi bilgileriyle beraber kaydını döndürür.
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
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
    }
}
