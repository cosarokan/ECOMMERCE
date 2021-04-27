using ECOMMERCE.CORE.Entities;
using ECOMMERCE.CORE.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ECOMMERCE.DATA.Repositories
{
    public class UsersRepository : RepositoryBase<Users, int>, IUsersRepository
    {
        public UsersRepository(DbContext dbDataContext) : base(dbDataContext)
        {

        }
    }
}
