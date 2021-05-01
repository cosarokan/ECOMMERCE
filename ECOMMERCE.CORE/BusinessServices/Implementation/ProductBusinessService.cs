using ECOMMERCE.CORE.Entities;
using ECOMMERCE.CORE.Repositories;
using System;
using System.Collections.Generic;

namespace ECOMMERCE.CORE.BusinessServices.Implementation
{
    public class ProductBusinessService : IProductBusinessService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ProductBusinessService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }
        public void Delete(int productId)
        {
            Product product = GetById(productId);
            _productRepository.Delete(product);
            _unitOfWork.Complete();
        }

        public List<Product> GetAll()
        {
            return _productRepository.All();
        }

        public List<Product> GetAllWithBrand()
        {
            return _productRepository.GetAllWithBrand();
        }

        public Product GetById(int productId)
        {
            return _productRepository.FindById(productId);
        }

        public void Save(Product product)
        {
            _productRepository.Add(product);
            _unitOfWork.Complete();
        }

        public void Update(Product product)
        {
            _productRepository.Update(product);
            _unitOfWork.Complete();
        }
    }
}
