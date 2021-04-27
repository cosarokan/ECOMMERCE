using ECOMMERCE.CORE.Entities;
using ECOMMERCE.CORE.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECOMMERCE.CORE.BusinessServices.Implementation
{
    public class ShoppingCartBusinessService : IShoppingCartBusinessService
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ShoppingCartBusinessService(IShoppingCartRepository shoppingCartRepository, IUnitOfWork unitOfWork)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _unitOfWork = unitOfWork;
        }
        public void Delete(int shoppingCartId)
        {
            ShoppingCart shoppingCart = GetById(shoppingCartId);
            _shoppingCartRepository.Delete(shoppingCart);
            _unitOfWork.Complete();
        }

        public List<ShoppingCart> GetAll()
        {
            return _shoppingCartRepository.All();
        }

        public ShoppingCart GetById(int shoppingCartId)
        {
            return _shoppingCartRepository.FindById(shoppingCartId);
        }

        public void Save(ShoppingCart shoppingCart)
        {
            _shoppingCartRepository.Add(shoppingCart);
            _unitOfWork.Complete();
        }

        public void Update(ShoppingCart shoppingCart)
        {
            _shoppingCartRepository.Update(shoppingCart);
            _unitOfWork.Complete();
        }
    }
}
