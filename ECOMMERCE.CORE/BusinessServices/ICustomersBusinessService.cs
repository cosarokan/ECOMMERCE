using ECOMMERCE.CORE.Entities;
using ECOMMERCE.CORE.Models;
using System.Collections.Generic;

namespace ECOMMERCE.CORE.BusinessServices
{
    public interface ICustomersBusinessService
    {
        /// <summary>
        /// Müşteri kaydetme işlemini yapar.
        /// </summary>
        /// <param name="customers"></param>
        ResponseModel<object> Save(Customers customers);

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

        /// <summary>
        /// Email adresine göre kullanıcıyı aktifleştirir
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        ResponseModel<object> AcivateCustomerByEmailAddress(string emailAddress);

        /// <summary>
        /// Kullanıcı login ekranı
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        ResponseModel<Customers> Login(string emailAddress, string password);
    }
}
