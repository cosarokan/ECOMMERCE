using ECOMMERCE.CORE.Entities;
using ECOMMERCE.CORE.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECOMMERCE.CORE.BusinessServices.Implementation
{
    public class ProductPropertyValuesBusinessService : IProductPropertyValuesBusinessService
    {
        private readonly IProductPropertyValuesRepository _productPropertyValuesRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ProductPropertyValuesBusinessService(IProductPropertyValuesRepository productPropertyValuesRepository, IUnitOfWork unitOfWork)
        {
            _productPropertyValuesRepository = productPropertyValuesRepository;
            _unitOfWork = unitOfWork;
        }
        public void Delete(int productPropertyValuesId)
        {
            ProductPropertyValues productPropertyValues = GetById(productPropertyValuesId);
            _productPropertyValuesRepository.Delete(productPropertyValues);
            _unitOfWork.Complete();
        }

        public List<ProductPropertyValues> GetAll()
        {
            return _productPropertyValuesRepository.All();
        }

        public ProductPropertyValues GetById(int productPropertyValuesId)
        {
            return _productPropertyValuesRepository.FindById(productPropertyValuesId);
        }

        public void Save(ProductPropertyValues productPropertyValues)
        {
            _productPropertyValuesRepository.Add(productPropertyValues);
            _unitOfWork.Complete();
        }

        public void Update(ProductPropertyValues productPropertyValues)
        {
            _productPropertyValuesRepository.Update(productPropertyValues);
            _unitOfWork.Complete();
        }
    }
}
