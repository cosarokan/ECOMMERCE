using ECOMMERCE.CORE.Entities;
using ECOMMERCE.CORE.Repositories;
using System.Collections.Generic;
using System.Linq;

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

        public List<ShoppingCart> GetAllByCustomerId(int customerId, List<ShoppingCart> currentShoppingCart)
        {
            List<ShoppingCart> shoppingCarts = _shoppingCartRepository.GetAllByCustomerId(customerId);
            if (currentShoppingCart != null && currentShoppingCart.Any())
            {
                foreach (var shoppingCart in currentShoppingCart)
                {
                    if (!shoppingCarts.Any(x => x.ProductId == shoppingCart.ProductId))
                    {
                        shoppingCarts.Add(shoppingCart);
                    }
                    else if (shoppingCarts.Any(x => x.ProductId == shoppingCart.ProductId))
                    {
                        shoppingCarts.First(x => x.ProductId == shoppingCart.ProductId).Quantity = shoppingCart.Quantity;
                    }
                }
                foreach (var item in shoppingCarts)
                {
                    if (item.Id == 0)
                    {
                        _shoppingCartRepository.Add(item);
                    }
                    else
                    {
                        _shoppingCartRepository.Update(item);
                    }
                }
            }
            _unitOfWork.Complete();
            return shoppingCarts;
        }

        public ShoppingCart GetById(int shoppingCartId)
        {
            return _shoppingCartRepository.FindById(shoppingCartId);
        }

        public void RemoveFromShoppingCart(int customerId, int productId)
        {
            ShoppingCart shoppingCart = _shoppingCartRepository.Where(x => x.CustomerId == customerId && x.ProductId == productId).SingleOrDefault();

            _shoppingCartRepository.Delete(shoppingCart);
            _unitOfWork.Complete();
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

        public void UpdateShoppingCarts(int customerId, List<ShoppingCart> currentShoppingCart)
        {
            List<ShoppingCart> shoppingCarts = _shoppingCartRepository.GetAllByCustomerId(customerId);
            if (currentShoppingCart != null && currentShoppingCart.Any())
            {
                foreach (var shoppingCart in currentShoppingCart)
                {
                    if (!shoppingCarts.Any(x => x.ProductId == shoppingCart.ProductId))
                    {
                        shoppingCarts.Add(shoppingCart);
                    }
                    else if (shoppingCarts.Any(x => x.ProductId == shoppingCart.ProductId))
                    {
                        shoppingCarts.First(x => x.ProductId == shoppingCart.ProductId).Quantity = shoppingCart.Quantity;
                    }
                }
                foreach (var item in shoppingCarts)
                {
                    if (item.Id == 0)
                    {
                        _shoppingCartRepository.Add(item);
                    }
                    else
                    {
                        _shoppingCartRepository.Update(item);
                    }
                }
                _unitOfWork.Complete();
            }
        }
    }
}
