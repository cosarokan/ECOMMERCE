using ECOMMERCE.CORE.Entities;
using ECOMMERCE.CORE.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ECOMMERCE.DATA.Repositories
{
    public class SliderRepository : RepositoryBase<Sliders, int>, ISliderRepository
    {
        public SliderRepository(DbContext dbDataContext) : base(dbDataContext)
        {

        }
    }
}
