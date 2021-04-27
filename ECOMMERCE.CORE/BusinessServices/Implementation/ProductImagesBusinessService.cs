using ECOMMERCE.CORE.Entities;
using ECOMMERCE.CORE.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECOMMERCE.CORE.BusinessServices.Implementation
{
    public class ProductImagesBusinessService : IProductImagesBusinessService
    {
        private readonly IProductImagesRepository _productImagesRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ProductImagesBusinessService(IProductImagesRepository productImagesRepository, IUnitOfWork unitOfWork)
        {
            _productImagesRepository = productImagesRepository;
            _unitOfWork = unitOfWork;
        }
        public void Delete(int productImagesId)
        {
            ProductImages productImages = GetById(productImagesId);
            _productImagesRepository.Delete(productImages);
            _unitOfWork.Complete();
        }

        public List<ProductImages> GetAll()
        {
            return _productImagesRepository.All();
        }

        public ProductImages GetById(int productImagesId)
        {
            return _productImagesRepository.FindById(productImagesId);
        }

        public void Save(ProductImages productImages)
        {
            _productImagesRepository.Add(productImages);
            _unitOfWork.Complete();
        }

        public void Update(ProductImages productImages)
        {
            _productImagesRepository.Update(productImages);
            _unitOfWork.Complete();
        }
    }
}
