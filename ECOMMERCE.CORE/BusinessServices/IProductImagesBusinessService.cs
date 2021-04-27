using ECOMMERCE.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECOMMERCE.CORE.BusinessServices
{
    public interface IProductImagesBusinessService
    {
        /// <summary>
        /// Ürün fotoğrafı kaydetme işlemini yapar.
        /// </summary>
        /// <param name="productImages"></param>
        void Save(ProductImages productImages);

        /// <summary>
        /// Ürün fotoğrafı güncelleme işlemini yapar.
        /// </summary>
        /// <param name="productImages"></param>
        void Update(ProductImages productImages);

        /// <summary>
        /// Ürün fotoğrafı silme işlemini yapar.
        /// </summary>
        /// <param name="productImagesId"></param>
        void Delete(int productImagesId);

        /// <summary>
        /// Tüm Ürün fotoğrafı kayıtlarını döndürür.
        /// </summary>
        /// <returns></returns>
        List<ProductImages> GetAll();

        /// <summary>
        /// Id'ye göre Ürün fotoğrafı kaydını döndürür.
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        ProductImages GetById(int productImagesId);
    }
}
