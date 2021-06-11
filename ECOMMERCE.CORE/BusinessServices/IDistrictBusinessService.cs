using ECOMMERCE.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECOMMERCE.CORE.BusinessServices
{
    public interface IDistrictBusinessService
    {
        /// <summary>
        /// İlçe kaydetme işlemini yapar.
        /// </summary>
        /// <param name="district"></param>
        void Save(District district);

        /// <summary>
        /// İlçe güncelleme işlemini yapar.
        /// </summary>
        /// <param name="district"></param>
        void Update(District district);

        /// <summary>
        /// İlçe silme işlemini yapar.
        /// </summary>
        /// <param name="districtId"></param>
        void Delete(int districtId);

        /// <summary>
        /// Tüm İlçe kayıtlarını döndürür.
        /// </summary>
        /// <returns></returns>
        List<District> GetAll();

        /// <summary>
        /// Id'ye göre İlçe kaydını döndürür.
        /// </summary>
        /// <param name="districtId"></param>
        /// <returns></returns>
        District GetById(int districtId);

        /// <summary>
        /// İle göre ilçe listesini döndürür.
        /// </summary>
        /// <param name="cityId">Şehir Id'si</param>
        /// <returns></returns>
        List<District> GetAllByCityId(int cityId);
    }
}
