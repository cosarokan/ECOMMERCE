using ECOMMERCE.CORE.Entities;
using ECOMMERCE.CORE.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECOMMERCE.CORE.BusinessServices.Implementation
{
    public class SubCategoriesBusinessService : ISubCategoriesBusinessService
    {
        private readonly ISubCategoriesRepository _subCategoriesRepository;
        private readonly IUnitOfWork _unitOfWork;
        public SubCategoriesBusinessService(ISubCategoriesRepository subCategoriesRepository, IUnitOfWork unitOfWork)
        {
            _subCategoriesRepository = subCategoriesRepository;
            _unitOfWork = unitOfWork;
        }
        public void Delete(int subCategoriesId)
        {
            SubCategories subCategories = GetById(subCategoriesId);
            _subCategoriesRepository.Delete(subCategories);
            _unitOfWork.Complete();
        }

        public List<SubCategories> GetAll()
        {
            return _subCategoriesRepository.All();
        }

        public List<SubCategories> GetAllWithCategories()
        {
            return _subCategoriesRepository.GetAllWithCategories();
        }

        public SubCategories GetById(int subCategoriesId)
        {
            return _subCategoriesRepository.FindById(subCategoriesId);
        }

        public void Save(SubCategories subCategories)
        {
            _subCategoriesRepository.Add(subCategories);
            _unitOfWork.Complete();
        }

        public void Update(SubCategories subCategories)
        {
            _subCategoriesRepository.Update(subCategories);
            _unitOfWork.Complete();
        }
    }
}
