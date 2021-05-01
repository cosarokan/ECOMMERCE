using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ECOMMERCE.WEBUI.Models;
using ECOMMERCE.CORE.BusinessServices;
using ECOMMERCE.CORE.Entities;
using System.Collections.Generic;
using System.Linq;
using ECOMMERCE.WEBUI.Models.ViewModels;

namespace ECOMMERCE.WEBUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoriesBusinessService _categoriesBusinessService;
        private readonly IProductBusinessService _productBusinessService;
        private readonly ISliderBusinessService _sliderBusinessService;

        public HomeController(ICategoriesBusinessService categoriesBusinessService, IProductBusinessService productBusinessService, ISliderBusinessService sliderBusinessService)
        {
            _categoriesBusinessService = categoriesBusinessService;
            _productBusinessService = productBusinessService;
            _sliderBusinessService = sliderBusinessService;
        }

        public IActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel();
            List<Categories> categories = _categoriesBusinessService.GetAllWithSubCategories();
            List<Product> products = _productBusinessService.GetAllWithBrand();
            List<Sliders> sliders = _sliderBusinessService.GetAll();

            homeViewModel.Categories = categories.Select(x => new CategoryModel
            {
                Id = x.Id,
                Description = x.Description,
                Image = x.Image,
                Name = x.Name,
                SubCategories = x.SubCategories.Select(y => new SubCategoryViewModel
                {
                    Description = y.Description,
                    Name = y.Name
                }).ToList()
            }).ToList();

            homeViewModel.Products = products.Select(x => new ProductModel
            {
                Id = x.Id,
                Image = x.Image,
                Model = x.BrandModel.Name,
                Brand = x.BrandModel.Brand.Name,
                ProductCode = x.ProductCode,
                Price = x.Price,
                Currency = x.Currency
            }).ToList();

            homeViewModel.Sliders = sliders.Select(x => new SliderModel
            {
                Description = x.Description,
                Image = x.Image,
                LinkTitle = x.LinkTitle,
                Title = x.Title
            }).ToList();

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
