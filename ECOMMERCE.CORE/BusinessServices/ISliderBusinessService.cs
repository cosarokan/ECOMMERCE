using ECOMMERCE.CORE.Entities;
using System.Collections.Generic;

namespace ECOMMERCE.CORE.BusinessServices
{
    /// <summary>
    /// Slider business logic katmanı
    /// </summary>
    public interface ISliderBusinessService
    {
        /// <summary>
        /// Slider kaydetme işlemini yapar.
        /// </summary>
        /// <param name="slider"></param>
        void Save(Sliders slider);

        /// <summary>
        /// Slider güncelleme işlemini yapar.
        /// </summary>
        /// <param name="slider"></param>
        void Update(Sliders slider);

        /// <summary>
        /// Slider silme işlemini yapar.
        /// </summary>
        /// <param name="sliderId"></param>
        void Delete(int sliderId);

        /// <summary>
        /// Tüm Slider kayıtlarını döndürür.
        /// </summary>
        /// <returns></returns>
        List<Sliders> GetAll();

        /// <summary>
        /// Id'ye göre Slider kaydını döndürür.
        /// </summary>
        /// <param name="sliderId"></param>
        /// <returns></returns>
        Sliders GetById(int sliderId);
    }
}
