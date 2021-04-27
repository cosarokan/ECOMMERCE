using ECOMMERCE.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECOMMERCE.CORE.BusinessServices
{
    public interface INeighborhoodBusinessService
    {
        /// <summary>
        /// Mahalle kaydetme işlemini yapar.
        /// </summary>
        /// <param name="neighborhood"></param>
        void Save(Neighborhood neighborhood);

        /// <summary>
        /// Mahalle güncelleme işlemini yapar.
        /// </summary>
        /// <param name="neighborhood"></param>
        void Update(Neighborhood neighborhood);

        /// <summary>
        /// Mahalle silme işlemini yapar.
        /// </summary>
        /// <param name="neighborhoodId"></param>
        void Delete(int neighborhoodId);

        /// <summary>
        /// Tüm Mahalle kayıtlarını döndürür.
        /// </summary>
        /// <returns></returns>
        List<Neighborhood> GetAll();

        /// <summary>
        /// Id'ye göre Mahalle kaydını döndürür.
        /// </summary>
        /// <param name="neighborhoodId"></param>
        /// <returns></returns>
        Neighborhood GetById(int neighborhoodId);
    }
}
