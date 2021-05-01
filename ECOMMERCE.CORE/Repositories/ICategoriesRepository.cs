using ECOMMERCE.CORE.Entities;
using System.Collections.Generic;

namespace ECOMMERCE.CORE.Repositories
{
    public interface ICategoriesRepository : IRepository<Categories, int> 
    {
        /// <summary>
        /// Tüm Kategori kayıtları alt kategorilerle döndürür.
        /// </summary>
        /// <returns></returns>
        List<Categories> GetAllWithSubCategories();
    }
}
