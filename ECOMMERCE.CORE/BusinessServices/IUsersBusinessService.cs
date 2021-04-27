using ECOMMERCE.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECOMMERCE.CORE.BusinessServices
{
    public interface IUsersBusinessService
    {
        /// <summary>
        /// Kullanıcı kaydetme işlemini yapar.
        /// </summary>
        /// <param name="users"></param>
        void Save(Users users);

        /// <summary>
        /// Kullanıcı güncelleme işlemini yapar.
        /// </summary>
        /// <param name="users"></param>
        void Update(Users users);

        /// <summary>
        /// Kullanıcı silme işlemini yapar.
        /// </summary>
        /// <param name="usersId"></param>
        void Delete(int usersId);

        /// <summary>
        /// Tüm Kullanıcı kayıtlarını döndürür.
        /// </summary>
        /// <returns></returns>
        List<Users> GetAll();

        /// <summary>
        /// Id'ye göre Kullanıcı kaydını döndürür.
        /// </summary>
        /// <param name="usersId"></param>
        /// <returns></returns>
        Users GetById(int usersId);
    }
}
