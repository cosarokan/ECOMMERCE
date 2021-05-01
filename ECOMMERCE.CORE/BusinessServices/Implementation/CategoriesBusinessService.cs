using ECOMMERCE.CORE.Entities;
using ECOMMERCE.CORE.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECOMMERCE.CORE.BusinessServices.Implementation
{
    public class CategoriesBusinessService : ICategoriesBusinessService
    {
        private readonly ICategoriesRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoriesBusinessService(ICategoriesRepository categoriesRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoriesRepository;
            _unitOfWork = unitOfWork;
        }
        public void Delete(int categoryId)
        {
            Categories category = GetById(categoryId);
            _categoryRepository.Delete(category);
            _unitOfWork.Complete();
        }

        public List<Categories> GetAll()
        {
            return _categoryRepository.All();
        }

        public List<Categories> GetAllWithSubCategories()
        {
            return _categoryRepository.GetAllWithSubCategories();
        }

        public Categories GetById(int categoryId)
        {
            return _categoryRepository.FindById(categoryId);
        }

        public void Save(Categories category)
        {
            _categoryRepository.Add(category);
            _unitOfWork.Complete();
        }

        public void Update(Categories category)
        {
            _categoryRepository.Update(category);
            _unitOfWork.Complete();
        }
    }
}
