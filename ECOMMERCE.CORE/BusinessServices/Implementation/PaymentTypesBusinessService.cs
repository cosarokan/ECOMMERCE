using ECOMMERCE.CORE.Entities;
using ECOMMERCE.CORE.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECOMMERCE.CORE.BusinessServices.Implementation
{
    public class PaymentTypesBusinessService : IPaymentTypesBusinessService
    {
        private readonly IPaymentTypesRepository _paymentTypesRepository;
        private readonly IUnitOfWork _unitOfWork;
        public PaymentTypesBusinessService(IPaymentTypesRepository paymentTypesRepository, IUnitOfWork unitOfWork)
        {
            _paymentTypesRepository = paymentTypesRepository;
            _unitOfWork = unitOfWork;
        }
        public void Delete(int paymentTypesId)
        {
            PaymentTypes paymentTypes = GetById(paymentTypesId);
            _paymentTypesRepository.Delete(paymentTypes);
            _unitOfWork.Complete();
        }

        public List<PaymentTypes> GetAll()
        {
            return _paymentTypesRepository.All();
        }

        public PaymentTypes GetById(int paymentTypesId)
        {
            return _paymentTypesRepository.FindById(paymentTypesId);
        }

        public void Save(PaymentTypes paymentTypes)
        {
            _paymentTypesRepository.Add(paymentTypes);
            _unitOfWork.Complete();
        }

        public void Update(PaymentTypes paymentTypes)
        {
            _paymentTypesRepository.Update(paymentTypes);
            _unitOfWork.Complete();
        }
    }
}
