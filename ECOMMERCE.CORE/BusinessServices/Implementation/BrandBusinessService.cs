using ECOMMERCE.CORE.Entities;
using ECOMMERCE.CORE.Repositories;
using System.Collections.Generic;

namespace ECOMMERCE.CORE.BusinessServices.Implementation
{
    public class BrandBusinessService : IBrandBusinessService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IUnitOfWork _unitOfWork;
        public BrandBusinessService(IBrandRepository brandRepository, IUnitOfWork unitOfWork)
        {
            _brandRepository = brandRepository;
            _unitOfWork = unitOfWork;
        }

        public void Delete(int brandId)
        {
            Brands brand = GetById(brandId);
            _brandRepository.Delete(brand);
            _unitOfWork.Complete();
        }

        public List<Brands> GetAll()
        {
            return _brandRepository.All();
        }

        public Brands GetById(int brandId)
        {
            return _brandRepository.FindById(brandId);
        }

        public void Save(Brands brand)
        {
            _brandRepository.Add(brand);
            _unitOfWork.Complete();
        }

        public void Update(Brands brand)
        {
            _brandRepository.Update(brand);
            _unitOfWork.Complete();
        }
    }
}