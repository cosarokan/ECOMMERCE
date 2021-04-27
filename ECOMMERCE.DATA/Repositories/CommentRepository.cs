using ECOMMERCE.CORE.Entities;
using ECOMMERCE.CORE.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ECOMMERCE.DATA.Repositories
{
    public class CommentRepository : RepositoryBase<Comment, int>, ICommentRepository
    {
        public CommentRepository(DbContext dbDataContext) : base(dbDataContext)
        {

        }
    }
}
