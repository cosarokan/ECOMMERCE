using ECOMMERCE.CORE.Entities;
using System.Collections.Generic;

namespace ECOMMERCE.CORE.BusinessServices
{
    /// <summary>
    /// Marka Business Logic Katmanı
    /// </summary>
    public interface IBrandBusinessService
    {
        /// <summary>
        /// Marka kaydetme işlemini yapar.
        /// </summary>
        /// <param name="brand"></param>
        void Save(Brands brand);

        /// <summary>
        /// Marka güncelleme işlemini yapar.
        /// </summary>
        /// <param name="brand"></param>
        void Update(Brands brand);

        /// <summary>
        /// Marka silme işlemini yapar.
        /// </summary>
        /// <param name="brandId"></param>
        void Delete(int brandId);

        /// <summary>
        /// Tüm Marka kayıtlarını döndürür.
        /// </summary>
        /// <returns></returns>
        List<Brands> GetAll();

        /// <summary>
        /// Id'ye göre Marka kaydını döndürür.
        /// </summary>
        /// <param name="brandId"></param>
        /// <returns></returns>
        Brands GetById(int brandId);
    }
}