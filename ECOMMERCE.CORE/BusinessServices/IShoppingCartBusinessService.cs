using ECOMMERCE.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECOMMERCE.CORE.BusinessServices
{
    public interface IShoppingCartBusinessService
    {
        /// <summary>
        /// Sepete ekle kaydetme işlemini yapar.
        /// </summary>
        /// <param name="shoppingCart"></param>
        void Save(ShoppingCart shoppingCart);

        /// <summary>
        /// Sepete ekle güncelleme işlemini yapar.
        /// </summary>
        /// <param name="shoppingCart"></param>
        void Update(ShoppingCart shoppingCart);

        /// <summary>
        /// Sepete ekle silme işlemini yapar.
        /// </summary>
        /// <param name="shoppingCartId"></param>
        void Delete(int shoppingCartId);

        /// <summary>
        /// Tüm Sepete ekle kayıtlarını döndürür.
        /// </summary>
        /// <returns></returns>
        List<ShoppingCart> GetAll();

        /// <summary>
        /// Id'ye göre Sepete ekle kaydını döndürür.
        /// </summary>
        /// <param name="shoppingCartId"></param>
        /// <returns></returns>
        ShoppingCart GetById(int shoppingCartId);
    }
}
