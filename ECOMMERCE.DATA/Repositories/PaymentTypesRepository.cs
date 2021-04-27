using ECOMMERCE.CORE.Entities;
using ECOMMERCE.CORE.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ECOMMERCE.DATA.Repositories
{
    public class PaymentTypesRepository : RepositoryBase<PaymentTypes, int>, IPaymentTypesRepository
    {
        public PaymentTypesRepository(DbContext dbDataContext) : base(dbDataContext)
        {

        }
    }
}
