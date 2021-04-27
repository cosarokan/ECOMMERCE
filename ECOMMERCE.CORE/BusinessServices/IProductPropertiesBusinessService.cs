using ECOMMERCE.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECOMMERCE.CORE.BusinessServices
{
    public interface IProductPropertiesBusinessService
    {
        /// <summary>
        /// Ürün özellikleri kaydetme işlemini yapar.
        /// </summary>
        /// <param name="productProperties"></param>
        void Save(ProductProperties productProperties);

        /// <summary>
        ///Ürün özellikleri güncelleme işlemini yapar.
        /// </summary>
        /// <param name="productProperties"></param>
        void Update(ProductProperties productProperties);

        /// <summary>
        /// Ürün özellikleri silme işlemini yapar.
        /// </summary>
        /// <param name="productPropertiesId"></param>
        void Delete(int productPropertiesId);

        /// <summary>
        /// Tüm Ürün özellikleri kayıtlarını döndürür.
        /// </summary>
        /// <returns></returns>
        List<ProductProperties> GetAll();

        /// <summary>
        /// Id'ye göre Ürün özellikleri kaydını döndürür.
        /// </summary>
        /// <param name="productPropertiesId"></param>
        /// <returns></returns>
        ProductProperties GetById(int productPropertiesId);
    }
}
