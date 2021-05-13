using ECOMMERCE.CORE.BusinessServices;
using ECOMMERCE.CORE.Entities;
using ECOMMERCE.WEBUI.Models;
using ECOMMERCE.WEBUI.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ECOMMERCE.WEBUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductBusinessService _productBusinessService;
        private readonly ICategoriesBusinessService _categoriesBusinessService;
        private readonly IProductTypesBusinessService _productTypesBusinessService;
        private readonly IProductPropertyValuesBusinessService _productPropertyValuesBusinessService;

        public ProductController(IProductBusinessService productBusinessService, ICategoriesBusinessService categoriesBusinessService, IProductTypesBusinessService productTypesBusinessService, IProductPropertyValuesBusinessService productPropertyValuesBusinessService)
        {
            _productBusinessService = productBusinessService;
            _categoriesBusinessService = categoriesBusinessService;
            _productTypesBusinessService = productTypesBusinessService;
            _productPropertyValuesBusinessService = productPropertyValuesBusinessService;
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
                productModel.CategoryCode = item.BrandModel.ProductType.SubCategory.Category.Code;
                productModel.SubCategoryCode = item.BrandModel.ProductType.SubCategory.Code;
                productModel.ProductTypeCode = item.BrandModel.ProductType.Code;

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
                Code = x.Code,
                SubCategories = x.SubCategories.Select(y => new SubCategoryModel
                {
                    Description = y.Description,
                    Name = y.Name,
                    Code = y.Code,
                    CategoryCode = y.Category.Code
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
                productModel.CategoryCode = item.BrandModel.ProductType.SubCategory.Category.Code;
                productModel.SubCategoryCode = item.BrandModel.ProductType.SubCategory.Code;
                productModel.ProductTypeCode = item.BrandModel.ProductType.Code;

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
                Code = x.Code,
                SubCategories = x.SubCategories.Select(y => new SubCategoryModel
                {
                    Description = y.Description,
                    Name = y.Name,
                    Code = y.Code,
                    CategoryCode = y.Category.Code
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
            List<ProductTypes> productTypes = _productTypesBusinessService.GetAllBySubCategory(subCategoryCode);

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
                productModel.CategoryCode = item.BrandModel.ProductType.SubCategory.Category.Code;
                productModel.SubCategoryCode = item.BrandModel.ProductType.SubCategory.Code;
                productModel.ProductTypeCode = item.BrandModel.ProductType.Code;

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
                Code = x.Code,
                SubCategories = x.SubCategories.Select(y => new SubCategoryModel
                {
                    Description = y.Description,
                    Name = y.Name,
                    Code = y.Code,
                    CategoryCode = y.Category.Code
                }).ToList()
            }).ToList();

            productViewModel.Brands = (from p in products
                                       group p by p.BrandModel.Brand into b
                                       select new BrandQuantityModel
                                       {
                                           BrandName = b.Key.Name,
                                           BrandQuantity = b.Count()
                                       }).OrderBy(x => x.BrandName).ToList();

            productViewModel.ProductTypes = productTypes.Select(x => new ProductTypeModel
            {
                Code = x.Code,
                Name = x.Name,
                CategoryCode = x.SubCategory.Category.Code,
                SubCategoryCode = x.SubCategory.Code
            }).ToList();

            return View(productViewModel);
        }

        [Route("Products/{categoryCode}/{subCategoryCode}/{productTypeCode}")]
        public IActionResult ProductFilter(string categoryCode, string subCategoryCode, string productTypeCode)
        {
            ProductFilterViewModel productViewModel = new ProductFilterViewModel();

            List<Product> products = _productBusinessService.GetAllWithBrandByProductType(categoryCode, subCategoryCode, productTypeCode);
            List<Categories> categories = _categoriesBusinessService.GetAllWithSubCategories();
            List<ProductTypes> productTypes = _productTypesBusinessService.GetAllBySubCategory(subCategoryCode);
            List<ProductPropertyValues> productPropertyValues = _productPropertyValuesBusinessService.GetAllByProductTypeCode(productTypeCode);

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
                productModel.CategoryCode = item.BrandModel.ProductType.SubCategory.Category.Code;
                productModel.SubCategoryCode = item.BrandModel.ProductType.SubCategory.Code;
                productModel.ProductTypeCode = item.BrandModel.ProductType.Code;

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
                Code = x.Code,
                SubCategories = x.SubCategories.Select(y => new SubCategoryModel
                {
                    Description = y.Description,
                    Name = y.Name,
                    Code = y.Code,
                    CategoryCode = y.Category.Code
                }).ToList()
            }).ToList();

            productViewModel.Brands = (from p in products
                                       group p by p.BrandModel.Brand into b
                                       select new BrandQuantityModel
                                       {
                                           BrandName = b.Key.Name,
                                           BrandQuantity = b.Count()
                                       }).OrderBy(x => x.BrandName).ToList();

            productViewModel.ProductTypes = productTypes.Select(x => new ProductTypeModel
            {
                Code = x.Code,
                Name = x.Name,
                CategoryCode = x.SubCategory.Category.Code,
                SubCategoryCode = x.SubCategory.Code
            }).ToList();

            //productViewModel.ProductTypeProperties = (from pv in productPropertyValues
            //                                          group pv by pv.ProductProperty into pp
            //                                          select new ProductPropertyFilterModel
            //                                          {
            //                                              Id = pp.Key.Id,
            //                                              Property = pp.Key.Property,
            //                                              Values = pp.Select(x => x.Value).ToList()
            //                                          }
            //    ).ToList();

            return View(productViewModel);
        }

        [Route("Products/{categoryCode}/{subCategoryCode}/{productType}/{productId}")]
        public IActionResult Detail(string categoryCode, string subCategoryCode, string productType, string productId)
        {
            DetailViewModel detailViewModel = new DetailViewModel();
            List<Categories> categories = _categoriesBusinessService.GetAllWithSubCategories();
            Product product = _productBusinessService.GetByIdWithDetails(Convert.ToInt32(productId));
            List<ProductTypes> productTypes = _productTypesBusinessService.GetAllBySubCategory(subCategoryCode);

            detailViewModel.Categories = categories.Select(x => new CategoryModel
            {
                Id = x.Id,
                Description = x.Description,
                Image = x.Image,
                Name = x.Name,
                Code = x.Code,
                SubCategories = x.SubCategories.Select(y => new SubCategoryModel
                {
                    Description = y.Description,
                    Name = y.Name,
                    Code = y.Code,
                    CategoryCode = y.Category.Code
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
                CategoryCode = product.BrandModel.ProductType.SubCategory.Category.Code,
                SubCategoryCode = product.BrandModel.ProductType.SubCategory.Code,
                ProductTypeCode = product.BrandModel.ProductType.Code
            };

            detailViewModel.Product.ProductProperties = new List<ProductPropertyModel>();
            foreach (ProductPropertyValues item in product.BrandModel.ProductPropertyValues)
            {
                ProductPropertyModel productProperty = new ProductPropertyModel();
                productProperty.Property = item.ProductProperty.Property;
                productProperty.Value = item.Value;
                detailViewModel.Product.ProductProperties.Add(productProperty);
            }

            detailViewModel.Product.Comments = product.Comments.Select(x => new ProductCommentModel
            {
                Comment = x.CommentText,
                CommentedBy = x.Customer.Name,
                CommentedDate = x.CommentDate
            }).ToList();

            detailViewModel.ProductTypes = productTypes.Select(x => new ProductTypeModel
            {
                Code = x.Code,
                Name = x.Name,
                CategoryCode = x.SubCategory.Category.Code,
                SubCategoryCode = x.SubCategory.Code
            }).ToList();

            return View(detailViewModel);
        }
    }
}

