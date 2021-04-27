using ECOMMERCE.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECOMMERCE.CORE.BusinessServices
{
    public interface ICustomersBusinessService
    {
        /// <summary>
        /// Müşteri kaydetme işlemini yapar.
        /// </summary>
        /// <param name="customers"></param>
        void Save(Customers customers);

        /// <summary>
        /// Müşteri güncelleme işlemini yapar.
        /// </summary>
        /// <param name="customers"></param>
        void Update(Customers customers);

        /// <summary>
        /// Müşteri silme işlemini yapar.
        /// </summary>
        /// <param name="customersId"></param>
        void Delete(int customersId);

        /// <summary>
        /// Tüm Müşteri kayıtlarını döndürür.
        /// </summary>
        /// <returns></returns>
        List<Customers> GetAll();

        /// <summary>
        /// Id'ye göre Müşteri kaydını döndürür.
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Customers GetById(int customerId);
    }
}
