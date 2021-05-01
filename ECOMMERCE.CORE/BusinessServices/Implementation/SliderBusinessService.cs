using ECOMMERCE.CORE.Entities;
using ECOMMERCE.CORE.Repositories;
using System.Collections.Generic;

namespace ECOMMERCE.CORE.BusinessServices.Implementation
{
    public class SliderBusinessService : ISliderBusinessService
    {
        private readonly ISliderRepository _sliderRepository;
        private readonly IUnitOfWork _unitOfWork;
        public SliderBusinessService(ISliderRepository sliderRepository, IUnitOfWork unitOfWork)
        {
            _sliderRepository = sliderRepository;
            _unitOfWork = unitOfWork;
        }
        public void Delete(int sliderId)
        {
            Sliders slider = GetById(sliderId);
            _sliderRepository.Delete(slider);
            _unitOfWork.Complete();
        }

        public List<Sliders> GetAll()
        {
            return _sliderRepository.All();
        }

        public Sliders GetById(int sliderId)
        {
            return _sliderRepository.FindById(sliderId);
        }

        public void Save(Sliders slider)
        {
            _sliderRepository.Add(slider);
            _unitOfWork.Complete();
        }

        public void Update(Sliders slider)
        {
            _sliderRepository.Update(slider);
            _unitOfWork.Complete();
        }
    }
}
