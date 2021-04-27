using ECOMMERCE.CORE.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ECOMMERCE.DATA.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(DbContext context)
        {
            _context = (ApplicationDbContext)context;
        }

        public void Complete()
        {
            _context.SaveChangesAsync();
        }
    }
}
