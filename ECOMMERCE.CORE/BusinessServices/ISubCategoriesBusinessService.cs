using ECOMMERCE.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECOMMERCE.CORE.BusinessServices
{
    public interface ISubCategoriesBusinessService
    {
        /// <summary>
        /// Alt Kategori ekle kaydetme işlemini yapar.
        /// </summary>
        /// <param name="subCategories"></param>
        void Save(SubCategories subCategories);

        /// <summary>
        /// Alt Kategori güncelleme işlemini yapar.
        /// </summary>
        /// <param name="subCategories"></param>
        void Update(SubCategories subCategories);

        /// <summary>
        /// Alt Kategori silme işlemini yapar.
        /// </summary>
        /// <param name="subCategoriesId"></param>
        void Delete(int subCategoriesId);

        /// <summary>
        /// Tüm Alt Kategori kayıtlarını döndürür.
        /// </summary>
        /// <returns></returns>
        List<SubCategories> GetAll();

        /// <summary>
        /// Id'ye göre Alt Kategori kaydını döndürür.
        /// </summary>
        /// <param name="subCategoriesId"></param>
        /// <returns></returns>
        SubCategories GetById(int subCategoriesId);

        /// <summary>
        /// Alt kategorileri bağlı olduğu kategori bilgileriyle döndürür
        /// </summary>
        /// <returns></returns>
        List<SubCategories> GetAllWithCategories();
    }
}
