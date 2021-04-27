using ECOMMERCE.CORE.Entities;
using ECOMMERCE.CORE.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECOMMERCE.CORE.BusinessServices.Implementation
{
    public class OrderDetailsBusinessService : IOrderDetailsBusinessService
    {
        private readonly IOrderDetailsRepository _orderDetailsRepository;
        private readonly IUnitOfWork _unitOfWork;
        public OrderDetailsBusinessService(IOrderDetailsRepository orderDetailsRepository, IUnitOfWork unitOfWork)
        {
            _orderDetailsRepository = orderDetailsRepository;
            _unitOfWork = unitOfWork;
        }
        public void Delete(int orderDetailId)
        {
            OrderDetails orderDetails = GetById(orderDetailId);
            _orderDetailsRepository.Delete(orderDetails);
            _unitOfWork.Complete();
        }

        public List<OrderDetails> GetAll()
        {
            return _orderDetailsRepository.All();
        }

        public OrderDetails GetById(int orderDetailId)
        {
            return _orderDetailsRepository.FindById(orderDetailId);
        }

        public void Save(OrderDetails orderDetails)
        {
            _orderDetailsRepository.Add(orderDetails);
            _unitOfWork.Complete();
        }

        public void Update(OrderDetails orderDetails)
        {
            _orderDetailsRepository.Update(orderDetails);
            _unitOfWork.Complete();
        }
    }
}
