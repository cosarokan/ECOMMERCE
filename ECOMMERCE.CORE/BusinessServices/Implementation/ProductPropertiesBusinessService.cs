using ECOMMERCE.CORE.Entities;
using ECOMMERCE.CORE.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECOMMERCE.CORE.BusinessServices.Implementation
{
    public class ProductPropertiesBusinessService : IProductPropertiesBusinessService
    {
        private readonly IProductPropertiesRepository _productPropertiesRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ProductPropertiesBusinessService(IProductPropertiesRepository productPropertiesRepository, IUnitOfWork unitOfWork)
        {
            _productPropertiesRepository = productPropertiesRepository;
            _unitOfWork = unitOfWork;
        }
        public void Delete(int productPropertiesId)
        {
            ProductProperties productProperties = GetById(productPropertiesId);
            _productPropertiesRepository.Delete(productProperties);
            _unitOfWork.Complete();
        }

        public List<ProductProperties> GetAll()
        {
            return _productPropertiesRepository.All();
        }

        public List<ProductProperties> GetAllByProductTypeCode(string productTypeCode)
        {
            return _productPropertiesRepository.GetAllByProductTypeCode(productTypeCode);
        }

        public ProductProperties GetById(int productPropertiesId)
        {
            return _productPropertiesRepository.FindById(productPropertiesId);
        }

        public void Save(ProductProperties productProperties)
        {
            _productPropertiesRepository.Add(productProperties);
            _unitOfWork.Complete();
        }

        public void Update(ProductProperties productProperties)
        {
            _productPropertiesRepository.Update(productProperties);
            _unitOfWork.Complete();
        }
    }
}
