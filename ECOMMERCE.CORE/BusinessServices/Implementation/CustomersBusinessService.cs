using ECOMMERCE.CORE.Entities;
using ECOMMERCE.CORE.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECOMMERCE.CORE.BusinessServices.Implementation
{
    public class CustomersBusinessService : ICustomersBusinessService
    {
        private readonly ICustomersRepository _customersRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CustomersBusinessService(ICustomersRepository customersRepository, IUnitOfWork unitOfWork)
        {
            _customersRepository = customersRepository;
            _unitOfWork = unitOfWork;
        }
        public void Delete(int customersId)
        {
            Customers customer = GetById(customersId);
            _customersRepository.Delete(customer);
            _unitOfWork.Complete();
        }

        public List<Customers> GetAll()
        {
            return _customersRepository.All();
        }

        public Customers GetById(int customerId)
        {
            return _customersRepository.FindById(customerId);
        }

        public void Save(Customers customers)
        {
            _customersRepository.Add(customers);
            _unitOfWork.Complete();
        }

        public void Update(Customers customers)
        {
            _customersRepository.Update(customers);
            _unitOfWork.Complete();
        }
    }

}
