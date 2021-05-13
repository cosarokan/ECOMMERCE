using ECOMMERCE.CORE.Entities;
using ECOMMERCE.CORE.Repositories;
using System;
using System.Collections.Generic;

namespace ECOMMERCE.CORE.BusinessServices.Implementation
{
    public class ProductTypesBusinessService : IProductTypesBusinessService
    {
        private readonly IProductTypesRepository _productTypesRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductTypesBusinessService(IProductTypesRepository productTypesRepository, IUnitOfWork unitOfWork)
        {
            _productTypesRepository = productTypesRepository;
            _unitOfWork = unitOfWork;
        }
        public void Delete(int productTypesId)
        {
            ProductTypes productTypes = GetById(productTypesId);
            _productTypesRepository.Delete(productTypes);
            _unitOfWork.Complete();
        }

        public List<ProductTypes> GetAll()
        {
            return _productTypesRepository.All();
        }

        public List<ProductTypes> GetAllBySubCategory(string subCategoryCode)
        {
            return _productTypesRepository.GetAllBySubCategory(subCategoryCode);
        }

        public ProductTypes GetById(int productTypesId)
        {
            return _productTypesRepository.FindById(productTypesId);
        }

        public void Save(ProductTypes productTypes)
        {
            _productTypesRepository.Add(productTypes);
            _unitOfWork.Complete();
        }

        public void Update(ProductTypes productTypes)
        {
            _productTypesRepository.Update(productTypes);
            _unitOfWork.Complete();
        }
    }
}
