using ECOMMERCE.CORE.Entities;
using System.Collections.Generic;

namespace ECOMMERCE.CORE.BusinessServices
{
    /// <summary>
    /// Model business logic katmanı
    /// </summary>
    public interface IBrandModelBusinessService
    {
        /// <summary>
        /// Model kaydetme işlemini yapar.
        /// </summary>
        /// <param name="brandModel"></param>
        void Save(BrandModels brandModel);

        /// <summary>
        /// Model güncelleme işlemini yapar.
        /// </summary>
        /// <param name="brandModel"></param>
        void Update(BrandModels brandModel);

        /// <summary>
        /// Model silme işlemini yapar.
        /// </summary>
        /// <param name="brandModelId"></param>
        void Delete(int brandModelId);

        /// <summary>
        /// Tüm Model kayıtlarını döndürür.
        /// </summary>
        /// <returns></returns>
        List<BrandModels> GetAll();

        /// <summary>
        /// Id'ye göre Model kaydını döndürür.
        /// </summary>
        /// <param name="brandModelId"></param>
        /// <returns></returns>
        BrandModels GetById(int brandModelId);
    }
}
