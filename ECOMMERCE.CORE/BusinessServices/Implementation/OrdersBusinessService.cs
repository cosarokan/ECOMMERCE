using ECOMMERCE.CORE.Constants;
using ECOMMERCE.CORE.Entities;
using ECOMMERCE.CORE.Models;
using ECOMMERCE.CORE.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ECOMMERCE.CORE.BusinessServices.Implementation
{
    public class OrdersBusinessService : IOrdersBusinessService
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IOrderDetailsRepository _orderDetailsRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        public OrdersBusinessService(IOrdersRepository ordersRepository, IOrderDetailsRepository orderDetailsRepository, IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _ordersRepository = ordersRepository;
            _orderDetailsRepository = orderDetailsRepository;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public ResponseModel<Orders> CreateOrder(int customerId, List<ShoppingCart> shoppingCarts)
        {
            decimal totalAmount = 0;
            foreach (ShoppingCart item in shoppingCarts)
            {
                Product product = _productRepository.FindById(item.ProductId);
                totalAmount += product.Price * item.Quantity;
            }

            Orders order = new Orders
            {
                CustomerId = customerId,
                OrderDate = DateTime.Now,
                PaymentTypeId = (int)PaymentType.KrediKarti,
                StatusId = (int)Status.Kabul,
                TotalAmount = totalAmount,
                ApprovedDate = DateTime.Now,
                ApprovedById = 1
            };

            _ordersRepository.Add(order);

            List<OrderDetails> orderDetails = shoppingCarts.Select(x => new OrderDetails
            {
                Count = x.Quantity,
                OrderId = order.Id,
                ProductId = x.ProductId
            }).ToList();

            foreach (OrderDetails item in orderDetails)
            {
                _orderDetailsRepository.Add(item);
            }

            _unitOfWork.Complete();

            return new ResponseModel<Orders>
            {
                IsSuccess = true,
                Message = "Siparişiniz başarıyla alınmıştır",
                Model = order
            };
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
