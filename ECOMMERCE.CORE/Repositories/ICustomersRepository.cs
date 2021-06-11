using ECOMMERCE.CORE.Entities;

namespace ECOMMERCE.CORE.Repositories
{
    public interface ICustomersRepository: IRepository<Customers, int>
    {
        /// <summary>
        /// Kullanıcı login ekranı
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Customers Login(string emailAddress, string password);
    }
}
