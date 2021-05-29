using ECOMMERCE.CORE.Entities;
using System.Collections.Generic;

namespace ECOMMERCE.CORE.Repositories
{
    public interface ISubCategoriesRepository : IRepository<SubCategories, int>
    {
        /// <summary>
        /// Alt kategorileri bağlı olduğu kategori bilgileriyle döndürür
        /// </summary>
        /// <returns></returns>
        List<SubCategories> GetAllWithCategories();
    }
}
