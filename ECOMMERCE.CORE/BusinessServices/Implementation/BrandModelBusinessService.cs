using ECOMMERCE.CORE.Entities;
using ECOMMERCE.CORE.Repositories;
using System.Collections.Generic;

namespace ECOMMERCE.CORE.BusinessServices.Implementation
{
    public class BrandModelBusinessService : IBrandModelBusinessService
    {
        private readonly IBrandModelRepository _brandModelRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BrandModelBusinessService(IBrandModelRepository brandModelRepository, IUnitOfWork unitOfWork)
        {
            _brandModelRepository = brandModelRepository;
            _unitOfWork = unitOfWork;
        }
        public void Delete(int brandModelId)
        {
            BrandModels brandModel = GetById(brandModelId);
            _brandModelRepository.Delete(brandModel);
            _unitOfWork.Complete();
        }

        public List<BrandModels> GetAll()
        {
            return _brandModelRepository.All();
        }

        public BrandModels GetById(int brandModelId)
        {
            return _brandModelRepository.FindById(brandModelId);
        }

        public void Save(BrandModels brandModel)
        {
            _brandModelRepository.Add(brandModel);
            _unitOfWork.Complete();
        }

        public void Update(BrandModels brandModel)
        {
            _brandModelRepository.Update(brandModel);
            _unitOfWork.Complete();
        }
    }
}
