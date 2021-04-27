using ECOMMERCE.CORE.Entities;
using ECOMMERCE.CORE.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECOMMERCE.CORE.BusinessServices.Implementation
{
    public class OrderStatusesBusinessService : IOrderStatusesBusinessService
    {
        private readonly IOrderStatusesRepository _orderStatusesRepository;
        private readonly IUnitOfWork _unitOfWork;
        public OrderStatusesBusinessService(IOrderStatusesRepository orderStatusesRepository, IUnitOfWork unitOfWork)
        {
            _orderStatusesRepository = orderStatusesRepository;
            _unitOfWork = unitOfWork;
        }
        public void Delete(int orderStatusesId)
        {
            OrderStatuses orderStatuses = GetById(orderStatusesId);
            _orderStatusesRepository.Delete(orderStatuses);
            _unitOfWork.Complete();
        }

        public List<OrderStatuses> GetAll()
        {
            return _orderStatusesRepository.All();
        }

        public OrderStatuses GetById(int orderStatusesId)
        {
            return _orderStatusesRepository.FindById(orderStatusesId);
        }

        public void Save(OrderStatuses orderStatuses)
        {
            _orderStatusesRepository.Add(orderStatuses);
            _unitOfWork.Complete();
        }

        public void Update(OrderStatuses orderStatuses)
        {
            _orderStatusesRepository.Update(orderStatuses);
            _unitOfWork.Complete();
        }
    }
}
