using ECOMMERCE.CORE.Entities;
using ECOMMERCE.CORE.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECOMMERCE.CORE.BusinessServices.Implementation
{
    public class CityBusinessService : ICityBusinessService
    {
        private readonly ICityRepository _cityRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CityBusinessService(ICityRepository cityRepository, IUnitOfWork unitOfWork)
        {
            _cityRepository = cityRepository;
            _unitOfWork = unitOfWork;
        }
        public void Delete(int cityId)
        {
            City city = GetById(cityId);
            _cityRepository.Delete(city);
            _unitOfWork.Complete();
        }

        public List<City> GetAll()
        {
            return _cityRepository.All();
        }

        public City GetById(int cityId)
        {
            return _cityRepository.FindById(cityId);
        }

        public void Save(City city)
        {
            _cityRepository.Add(city);
            _unitOfWork.Complete();
        }

        public void Update(City city)
        {
            _cityRepository.Update(city);
            _unitOfWork.Complete();
        }
    }
}
