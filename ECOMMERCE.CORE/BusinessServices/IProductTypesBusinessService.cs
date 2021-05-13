using ECOMMERCE.CORE.Entities;
using System.Collections.Generic;

namespace ECOMMERCE.CORE.BusinessServices
{
    public interface IProductTypesBusinessService
    {
        /// <summary>
        /// Ürün Tipi kaydetme işlemini yapar.
        /// </summary>
        /// <param name="productTypes"></param>
        void Save(ProductTypes productTypes);

        /// <summary>
        /// Ürün Tipi güncelleme işlemini yapar.
        /// </summary>
        /// <param name="productTypes"></param>
        void Update(ProductTypes productTypes);

        /// <summary>
        /// Ürün Tipi silme işlemini yapar.
        /// </summary>
        /// <param name="productTypesId"></param>
        void Delete(int productTypesId);

        /// <summary>
        /// Tüm Ürün Tipi kayıtlarını döndürür.
        /// </summary>
        /// <returns></returns>
        List<ProductTypes> GetAll();

        /// <summary>
        /// Id'ye göre Ürün Tipi kaydını döndürür.
        /// </summary>
        /// <param name="productTypesId"></param>
        /// <returns></returns>
        ProductTypes GetById(int productTypesId);

        /// <summary>
        /// Alt kategoriye göre ürün tiplerini döndürür.
        /// </summary>
        /// <param name="subCategoryCode"></param>
        /// <returns></returns>
        List<ProductTypes> GetAllBySubCategory(string subCategoryCode);
    }
}
