using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ECOMMERCE.WEBUI.Models;
using ECOMMERCE.CORE.BusinessServices;
using ECOMMERCE.CORE.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ECOMMERCE.WEBUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoriesBusinessService _categoriesBusinessService;
        private readonly ISubCategoriesBusinessService _subCategoriesBusinessService;

        public HomeController(ICategoriesBusinessService categoriesBusinessService, ISubCategoriesBusinessService subCategoriesBusinessService)
        {
            _categoriesBusinessService = categoriesBusinessService;
            _subCategoriesBusinessService = subCategoriesBusinessService;
        }

        public IActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel();
            List<Categories> categories = _categoriesBusinessService.GetAll();

            homeViewModel.Categories = categories.Select(x => new CategoryViewModel
            {
                Id = x.Id,
                Description = x.Description,
                Image = x.Image,
                Name = x.Name
            }).ToList();

            List<SubCategories> subCategories = _subCategoriesBusinessService.GetAll();
            foreach (var category in homeViewModel.Categories)
            {
                category.SubCategories = subCategories.Where(x => x.CategoryId == category.Id).Select(x =>  new SubCategoryViewModel
                {
                    Name = x.Name,
                    Description  =x.Description
                }).ToList();
            }

            return View(homeViewModel);
        }

        public IActionResult Privacy()
        {
            
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
