using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ECOMMERCE.WEBUI.Models;
using ECOMMERCE.CORE.BusinessServices;
using ECOMMERCE.CORE.Entities;
using System.Collections.Generic;
using System.Linq;
using ECOMMERCE.WEBUI.Models.ViewModels;
using Microsoft.Extensions.Configuration;

namespace ECOMMERCE.WEBUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoriesBusinessService _categoriesBusinessService;
        private readonly IProductBusinessService _productBusinessService;
        private readonly ISliderBusinessService _sliderBusinessService;
        private readonly IConfiguration _iConfig;

        public HomeController(IConfiguration iConfig, ICategoriesBusinessService categoriesBusinessService, IProductBusinessService productBusinessService, ISliderBusinessService sliderBusinessService)
        {
            _iConfig = iConfig;
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
                Code = x.Code,
                Name = x.Name,
                SubCategories = x.SubCategories.Select(y => new SubCategoryModel
                {
                    Description = y.Description,
                    Name = y.Name,
                    Code = y.Code,
                    CategoryCode = y.Category.Code
                }).ToList()
            }).ToList();

            //homeViewModel.Products = products.Select(x => new ProductModel
            //{
            //    Id = x.Id,
            //    Image = x.Image,
            //    Model = x.BrandModel.Name,
            //    Brand = x.BrandModel.Brand.Name,
            //    ProductCode = x.ProductCode,
            //    CategoryCode = x.BrandModel.ProductType.SubCategory.Category.Code,
            //    SubCategoryCode = x.BrandModel.ProductType.SubCategory.Code,
            //    ProductTypeCode = x.BrandModel.ProductType.Code,
            //    Price = x.Price,
            //    Currency = x.Currency
            //}).ToList();

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

        [HttpPost]
        public ActionResult GetProducts(int pageNumber)
        {
            string itemsParPage = _iConfig.GetSection("ItemsPerPage").Value;

            List<Product> products = _productBusinessService.GetAllWithBrand(pageNumber, int.Parse(itemsParPage));

            List<ProductModel> productViewModelList = products.Select(x => new ProductModel
            {
                Id = x.Id,
                Image = x.Image,
                Model = x.BrandModel.Name,
                Brand = x.BrandModel.Brand.Name,
                ProductCode = x.ProductCode,
                CategoryCode = x.BrandModel.ProductType.SubCategory.Category.Code,
                SubCategoryCode = x.BrandModel.ProductType.SubCategory.Code,
                ProductTypeCode = x.BrandModel.ProductType.Code,
                Price = x.Price,
                Currency = x.Currency,
                ImageSrc = string.Format("{0}://{1}/{2}", Request.Scheme, Request.Host, x.Image),
                Url = string.Format("Products/{0}/{1}/{2}/{3}", x.BrandModel.ProductType.SubCategory.Category.Code, x.BrandModel.ProductType.SubCategory.Code,
                  x.BrandModel.ProductType.Code,
                  x.Id)
            }).ToList();
            return Json(new { Data = productViewModelList });
        }

        [HttpPost]
        public ActionResult GetProductsCount()
        {
            int productCount = _productBusinessService.Count();
            return Json(new { Data = productCount });
        }
    }
}
