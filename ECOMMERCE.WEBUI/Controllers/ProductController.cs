using ECOMMERCE.CORE.BusinessServices;
using ECOMMERCE.CORE.Entities;
using ECOMMERCE.WEBUI.Models;
using ECOMMERCE.WEBUI.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ECOMMERCE.WEBUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductBusinessService _productBusinessService;
        private readonly ICategoriesBusinessService _categoriesBusinessService;
        public ProductController(IProductBusinessService productBusinessService, ICategoriesBusinessService categoriesBusinessService)
        {
            _productBusinessService = productBusinessService;
            _categoriesBusinessService = categoriesBusinessService;
        }

        [Route("Products")]
        public IActionResult Index()
        {
            ProductViewModel productViewModel = new ProductViewModel();

            List<Product> products = _productBusinessService.GetAllWithBrand();
            List<Categories> categories = _categoriesBusinessService.GetAllWithSubCategories();

            List<ProductModel> productModelList = new List<ProductModel>();
            foreach (Product item in products)
            {
                ProductModel productModel = new ProductModel();
                productModel.Brand = item.BrandModel.Brand.Name;
                productModel.Currency = item.Currency;
                productModel.Image = item.Image;
                productModel.Model = item.BrandModel.Name;
                productModel.Price = item.Price;
                productModel.ProductCode = item.ProductCode;
                productModel.Id = item.Id;

                productModelList.Add(productModel);
            }
            productViewModel.Products = productModelList;

            //linq lambda
            productViewModel.Categories = categories.Select(x => new CategoryModel
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

            productViewModel.Brands = (from p in products
                                       group p by p.BrandModel.Brand into b
                                       select new BrandQuantityModel
                                       {
                                           BrandName = b.Key.Name,
                                           BrandQuantity = b.Count()
                                       }).OrderBy(x => x.BrandName).ToList();

            return View(productViewModel);
        }

        [Route("Products/{category}")]
        public IActionResult Index(string category)
        {
            return View();
        }

        [Route("Products/{category}/{subCategory}")]
        public IActionResult Index(string category, string subCategory)
        {
            return View();
        }

        [Route("Products/{category}/{subCategory}/{productType}")]
        public IActionResult Index(string category, string subCategory, string productType)
        {
            return View();
        }

        [Route("Products/{category}/{subCategory}/{productType}/{productId}")]
        public IActionResult Detail(string category, string subCategory, string productType, string productId)
        {
            return View();
        }
    }
}

//http://asdasd.com/Products/Bilgisayar/Notebook/Oyun-Bilgisayari/HP1238798
