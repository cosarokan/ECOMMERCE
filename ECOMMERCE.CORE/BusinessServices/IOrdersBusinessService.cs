using ECOMMERCE.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECOMMERCE.CORE.BusinessServices
{
    public interface IOrdersBusinessService
    {
        /// <summary>
        /// Sipariş kaydetme işlemini yapar.
        /// </summary>
        /// <param name="orders"></param>
        void Save(Orders orders);

        /// <summary>
        /// Sipariş güncelleme işlemini yapar.
        /// </summary>
        /// <param name="brand"></param>
        void Update(Orders orders);

        /// <summary>
        /// Sipariş silme işlemini yapar.
        /// </summary>
        /// <param name="ordersId"></param>
        void Delete(int ordersId);

        /// <summary>
        /// Tüm Sipariş kayıtlarını döndürür.
        /// </summary>
        /// <returns></returns>
        List<Orders> GetAll();

        /// <summary>
        /// Id'ye göre Sipariş kaydını döndürür.
        /// </summary>
        /// <param name="ordersId"></param>
        /// <returns></returns>
        Orders GetById(int ordersId);
    }
}
