using ECOMMERCE.CORE.Entities;
using ECOMMERCE.CORE.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECOMMERCE.CORE.BusinessServices.Implementation
{
    public class OrdersBusinessService : IOrdersBusinessService
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IUnitOfWork _unitOfWork;
        public OrdersBusinessService(IOrdersRepository ordersRepository, IUnitOfWork unitOfWork)
        {
            _ordersRepository = ordersRepository;
            _unitOfWork = unitOfWork;
        }
        public void Delete(int ordersId)
        {
            Orders orders = GetById(ordersId);
            _ordersRepository.Delete(orders);
            _unitOfWork.Complete();
        }

        public List<Orders> GetAll()
        {
            return _ordersRepository.All();
        }

        public Orders GetById(int ordersId)
        {
            return _ordersRepository.FindById(ordersId);
        }

        public void Save(Orders orders)
        {
            _ordersRepository.Add(orders);
            _unitOfWork.Complete();
        }

        public void Update(Orders orders)
        {
            _ordersRepository.Update(orders);
            _unitOfWork.Complete();
        }
    }
}
