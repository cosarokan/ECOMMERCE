using ECOMMERCE.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECOMMERCE.CORE.BusinessServices
{
    public interface IOrderStatusesBusinessService
    {
        /// <summary>
        /// Sipariş durumu kaydetme işlemini yapar.
        /// </summary>
        /// <param name="orderStatuses"></param>
        void Save(OrderStatuses orderStatuses);

        /// <summary>
        /// Sipariş durumu güncelleme işlemini yapar.
        /// </summary>
        /// <param name="orderStatuses"></param>
        void Update(OrderStatuses orderStatuses);

        /// <summary>
        /// Sipariş durumu silme işlemini yapar.
        /// </summary>
        /// <param name="orderStatusesId"></param>
        void Delete(int orderStatusesId);

        /// <summary>
        /// Tüm Sipariş durumu kayıtlarını döndürür.
        /// </summary>
        /// <returns></returns>
        List<OrderStatuses> GetAll();

        /// <summary>
        /// Id'ye göre Sipariş durumu kaydını döndürür.
        /// </summary>
        /// <param name="orderStatusesId"></param>
        /// <returns></returns>
        OrderStatuses GetById(int orderStatusesId);
    }
}
