using ECOMMERCE.CORE.Entities;
using ECOMMERCE.CORE.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECOMMERCE.CORE.BusinessServices.Implementation
{
    public class DistrictBusinessService : IDistrictBusinessService
    {
        private readonly IDistrictRepository _districtRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DistrictBusinessService(IDistrictRepository districtRepository, IUnitOfWork unitOfWork)
        {
            _districtRepository = districtRepository;
            _unitOfWork = unitOfWork;
        }
        public void Delete(int districtId)
        {
            District district = GetById(districtId);
            _districtRepository.Delete(district);
            _unitOfWork.Complete();
        }

        public List<District> GetAll()
        {
            return _districtRepository.All();
        }

        public District GetById(int districtId)
        {
            return _districtRepository.FindById(districtId);
        }

        public void Save(District district)
        {
            _districtRepository.Add(district);
            _unitOfWork.Complete();
        }

        public void Update(District district)
        {
            _districtRepository.Update(district);
            _unitOfWork.Complete();
        }
    }
}
