using ECOMMERCE.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
