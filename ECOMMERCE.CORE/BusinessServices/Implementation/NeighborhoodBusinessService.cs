using ECOMMERCE.CORE.Entities;
using ECOMMERCE.CORE.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECOMMERCE.CORE.BusinessServices.Implementation
{
    public class NeighborhoodBusinessService : INeighborhoodBusinessService
    {
        private readonly INeighborhoodRepository _neighborhoodRepository;
        private readonly IUnitOfWork _unitOfWork;
        public NeighborhoodBusinessService(INeighborhoodRepository neighborhoodRepository, IUnitOfWork unitOfWork)
        {
            _neighborhoodRepository = neighborhoodRepository;
        }
        public void Delete(int neighborhoodId)
        {
            Neighborhood neighborhood = GetById(neighborhoodId);
            _neighborhoodRepository.Delete(neighborhood);
            _unitOfWork.Complete();
        }

        public List<Neighborhood> GetAll()
        {
            return _neighborhoodRepository.All();
        }

        public Neighborhood GetById(int neighborhoodId)
        {
            return _neighborhoodRepository.FindById(neighborhoodId);
        }

        public void Save(Neighborhood neighborhood)
        {
            _neighborhoodRepository.Add(neighborhood);
            _unitOfWork.Complete();
        }

        public void Update(Neighborhood neighborhood)
        {
            _neighborhoodRepository.Update(neighborhood);
            _unitOfWork.Complete();
        }
    }
}
