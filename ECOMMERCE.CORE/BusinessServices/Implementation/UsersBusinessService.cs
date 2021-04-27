using ECOMMERCE.CORE.Entities;
using ECOMMERCE.CORE.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECOMMERCE.CORE.BusinessServices.Implementation
{
    public class UsersBusinessService : IUsersBusinessService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UsersBusinessService(IUsersRepository usersRepository, IUnitOfWork unitOfWork)
        {
            _usersRepository = usersRepository;
            _unitOfWork = unitOfWork;
        }
        public void Delete(int usersId)
        {
            Users users = GetById(usersId);
            _usersRepository.Delete(users);
            _unitOfWork.Complete();
        }

        public List<Users> GetAll()
        {
            return _usersRepository.All();
        }

        public Users GetById(int usersId)
        {
            return _usersRepository.FindById(usersId);
        }

        public void Save(Users users)
        {
            _usersRepository.Add(users);
            _unitOfWork.Complete();
        }

        public void Update(Users users)
        {
            _usersRepository.Update(users);
            _unitOfWork.Complete();
        }
    }
}
