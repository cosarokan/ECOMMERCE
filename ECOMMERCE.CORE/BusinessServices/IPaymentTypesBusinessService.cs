using ECOMMERCE.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECOMMERCE.CORE.BusinessServices
{
    public interface IPaymentTypesBusinessService
    {
        /// <summary>
        /// Ödeme Tipi kaydetme işlemini yapar.
        /// </summary>
        /// <param name="paymentTypes"></param>
        void Save(PaymentTypes paymentTypes);

        /// <summary>
        /// Ödeme Tipi güncelleme işlemini yapar.
        /// </summary>
        /// <param name="paymentTypes"></param>
        void Update(PaymentTypes paymentTypes);

        /// <summary>
        /// Ödeme Tipi silme işlemini yapar.
        /// </summary>
        /// <param name="paymentTypesId"></param>
        void Delete(int paymentTypesId);

        /// <summary>
        /// Tüm Ödeme Tipi kayıtlarını döndürür.
        /// </summary>
        /// <returns></returns>
        List<PaymentTypes> GetAll();

        /// <summary>
        /// Id'ye göre Ödeme Tipi kaydını döndürür.
        /// </summary>
        /// <param name="paymentTypesId"></param>
        /// <returns></returns>
        PaymentTypes GetById(int paymentTypesId);
    }
}
