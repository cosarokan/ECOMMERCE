using ECOMMERCE.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECOMMERCE.CORE.BusinessServices
{
    public interface IOrderDetailsBusinessService
    {
        /// <summary>
        /// Sipariş detayı kaydetme işlemini yapar.
        /// </summary>
        /// <param name="orderDetails"></param>
        void Save(OrderDetails orderDetails);

        /// <summary>
        /// Sipariş detayı güncelleme işlemini yapar.
        /// </summary>
        /// <param name="orderDetails"></param>
        void Update(OrderDetails orderDetails);

        /// <summary>
        /// Sipariş detayı silme işlemini yapar.
        /// </summary>
        /// <param name="orderDetailId"></param>
        void Delete(int orderDetailId);

        /// <summary>
        /// Tüm Sipariş detayı kayıtlarını döndürür.
        /// </summary>
        /// <returns></returns>
        List<OrderDetails> GetAll();

        /// <summary>
        /// Id'ye göre Sipariş detayı kaydını döndürür.
        /// </summary>
        /// <param name="orderDetailId"></param>
        /// <returns></returns>
        OrderDetails GetById(int orderDetailId);
    }
}
