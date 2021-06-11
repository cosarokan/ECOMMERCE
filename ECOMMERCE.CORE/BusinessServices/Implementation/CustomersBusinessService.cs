using ECOMMERCE.CORE.Entities;
using ECOMMERCE.CORE.Models;
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

        public ResponseModel<object> AcivateCustomerByEmailAddress(string emailAddress)
        {
            ResponseModel<object> response = new ResponseModel<object>();
            Customers customer = _customersRepository.Single(x => x.Email == emailAddress);
            if (customer == null)
            {
                response.IsSuccess = false;
                response.Message = $"{emailAddress} email adresine sahip bir kullanıcı bulunamadı!";
                return response;
            }
            if (customer.IsActive)
            {
                response.IsSuccess = false;
                response.Message = $"{emailAddress} email adresine sahip zaten aktif durumda!";
                return response;
            }

            customer.IsActive = true;
            Update(customer);

            response.IsSuccess = true;
            return response;
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

        public ResponseModel<Customers> Login(string emailAddress, string password)
        {
            ResponseModel<Customers> response = new ResponseModel<Customers>();

            Customers customer = _customersRepository.Login(emailAddress, password);
            if (customer == null)
            {
                response.IsSuccess = false;
                response.Message = "Email adresi veya parola hatalı!";
                return response;
            }
            if (customer != null && !customer.IsActive)
            {
                response.IsSuccess = false;
                response.Message = "Kullanıcı aktif edilmemiş!";

                response.Model = customer;
                return response;
            }

            response.IsSuccess = true;
            response.Model = customer;

            return response;
        }

        public ResponseModel<object> Save(Customers customers)
        {
            ResponseModel<object> response = new ResponseModel<object>();
            Customers customer = _customersRepository.Single(x => x.Email == customers.Email);
            if (customer != null)
            {
                response.IsSuccess = false;
                response.Message = "Bu mail adresiyle daha önce kayıt yapılmış!";
                return response;
            }
            _customersRepository.Add(customers);
            _unitOfWork.Complete();
            response.IsSuccess = true;
            return response;
        }

        public void Update(Customers customers)
        {
            _customersRepository.Update(customers);
            _unitOfWork.Complete();
        }
    }

}
