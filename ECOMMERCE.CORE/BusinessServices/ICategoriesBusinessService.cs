using ECOMMERCE.CORE.Entities;
using System.Collections.Generic;

namespace ECOMMERCE.CORE.BusinessServices
{
    public interface ICategoriesBusinessService
    {
        /// <summary>
        /// Kategori kaydetme işlemini yapar.
        /// </summary>
        /// <param name="brand"></param>
        void Save(Categories category);

        /// <summary>
        /// Kategori güncelleme işlemini yapar.
        /// </summary>
        /// <param name="brand"></param>
        void Update(Categories category);

        /// <summary>
        /// Kategori silme işlemini yapar.
        /// </summary>
        /// <param name="categoryId"></param>
        void Delete(int categoryId);

        /// <summary>
        /// Tüm Kategori kayıtlarını döndürür.
        /// </summary>
        /// <returns></returns>
        List<Categories> GetAll();

        /// <summary>
        /// Id'ye göre Kategori kaydını döndürür.
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        Categories GetById(int categoryId);

        /// <summary>
        /// Tüm Kategori kayıtları alt kategorilerle döndürür.
        /// </summary>
        /// <returns></returns>
        List<Categories> GetAllWithSubCategories();
    }
}
