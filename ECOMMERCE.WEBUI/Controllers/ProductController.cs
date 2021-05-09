using ECOMMERCE.CORE.BusinessServices;
using ECOMMERCE.CORE.Entities;
using ECOMMERCE.WEBUI.Models;
using ECOMMERCE.WEBUI.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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

            ProductViewModel productViewModel = new ProductViewModel();
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

        [Route("Products/{categoryCode}")]
        public IActionResult ProductFilter(string categoryCode)
        {
            ProductFilterViewModel productViewModel = new ProductFilterViewModel();

            List<Product> products = _productBusinessService.GetAllWithBrandByCategoryCode(categoryCode);
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

        [Route("Products/{categoryCode}/{subCategoryCode}")]
        public IActionResult ProductFilter(string categoryCode, string subCategoryCode)
        {
            ProductFilterViewModel productViewModel = new ProductFilterViewModel();

            List<Product> products = _productBusinessService.GetAllWithBrandBySubCategoryCode(categoryCode, subCategoryCode);
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

        [Route("Products/{categoryCode}/{subCategoryCode}/{productType}")]
        public IActionResult ProductFilter(string categoryCode, string subCategoryCode, string productType)
        {
            ProductFilterViewModel productViewModel = new ProductFilterViewModel();

            List<Product> products = _productBusinessService.GetAllWithBrandByProductType(categoryCode, subCategoryCode, productType);
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

        [Route("Products/{categoryCode}/{subCategoryCode}/{productType}/{productId}")]
        public IActionResult Detail(string categoryCode, string subCategoryCode, string productType, string productId)
        {
            DetailViewModel detailViewModel = new DetailViewModel();
            List<Categories> categories = _categoriesBusinessService.GetAllWithSubCategories();
            Product product = _productBusinessService.GetByIdWithDetails(Convert.ToInt32(productId));

            detailViewModel.Categories = categories.Select(x => new CategoryModel
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

            detailViewModel.Product = new ProductModel
            {
                Brand = product.BrandModel.Brand.Name,
                Currency = product.Currency,
                Image = product.Image,
                Model = product.BrandModel.Name,
                Price = product.Price,
                ProductCode = product.ProductCode,
                Id = product.Id,
            };

            return View(detailViewModel);
        }
    }
}

