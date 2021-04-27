using ECOMMERCE.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECOMMERCE.CORE.BusinessServices
{
    public interface ICityBusinessService
    {
        /// <summary>
        /// Şehir kaydetme işlemini yapar.
        /// </summary>
        /// <param name="city"></param>
        void Save(City city);

        /// <summary>
        /// Şehir güncelleme işlemini yapar.
        /// </summary>
        /// <param name="city"></param>
        void Update(City city);

        /// <summary>
        /// Şehir silme işlemini yapar.
        /// </summary>
        /// <param name="cityId"></param>
        void Delete(int cityId);

        /// <summary>
        /// Tüm Şehir kayıtlarını döndürür.
        /// </summary>
        /// <returns></returns>
        List<City> GetAll();

        /// <summary>
        /// Id'ye göre Şehir kaydını döndürür.
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        City GetById(int cityId);
    }
}
