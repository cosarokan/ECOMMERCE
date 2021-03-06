using ECOMMERCE.CORE.Entities;
using System.Collections.Generic;

namespace ECOMMERCE.CORE.BusinessServices
{
    public interface IProductPropertyValuesBusinessService
    {
        /// <summary>
        /// Ürün özellik değeri kaydetme işlemini yapar.
        /// </summary>
        /// <param name="productPropertyValues"></param>
        void Save(ProductPropertyValues productPropertyValues);

        /// <summary>
        /// Ürün özellik değeri güncelleme işlemini yapar.
        /// </summary>
        /// <param name="productPropertyValues"></param>
        void Update(ProductPropertyValues productPropertyValues);

        /// <summary>
        /// Ürün özellik değeri silme işlemini yapar.
        /// </summary>
        /// <param name="productPropertyValuesId"></param>
        void Delete(int productPropertyValuesId);

        /// <summary>
        /// Tüm Ürün özellik değeri kayıtlarını döndürür.
        /// </summary>
        /// <returns></returns>
        List<ProductPropertyValues> GetAll();

        /// <summary>
        /// Id'ye göre Ürün özellik değeri kaydını döndürür.
        /// </summary>
        /// <param name="productPropertyValuesId"></param>
        /// <returns></returns>
        ProductPropertyValues GetById(int productPropertyValuesId);

        /// <summary>
        /// Ütün tipine göre ürün özelliklerini döndürür.
        /// </summary>
        /// <param name="productTypeCode"></param>
        /// <returns></returns>
        List<ProductPropertyValues> GetAllByProductTypeCode(string productTypeCode);
    }
}
