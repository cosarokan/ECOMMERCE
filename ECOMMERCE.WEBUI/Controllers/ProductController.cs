using ECOMMERCE.CORE.BusinessServices;
using ECOMMERCE.CORE.Entities;
using ECOMMERCE.CORE.Models;
using ECOMMERCE.WEBUI.Extensions;
using ECOMMERCE.WEBUI.Models;
using ECOMMERCE.WEBUI.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
        private readonly IProductPropertiesBusinessService _productPropertiesBusinessService;
        private readonly IShoppingCartBusinessService _shoppingCartBusinessService;
        private readonly ICommentBusinessService _commentBusinessService;
        private readonly IConfiguration _iConfig;

        public ProductController(IConfiguration iConfig, IProductBusinessService productBusinessService, ICategoriesBusinessService categoriesBusinessService, IProductTypesBusinessService productTypesBusinessService, IProductPropertiesBusinessService productPropertiesBusinessService, IShoppingCartBusinessService shoppingCartBusinessService, ICommentBusinessService commentBusinessService)
        {
            _iConfig = iConfig;
            _productBusinessService = productBusinessService;
            _categoriesBusinessService = categoriesBusinessService;
            _productTypesBusinessService = productTypesBusinessService;
            _productPropertiesBusinessService = productPropertiesBusinessService;
            _shoppingCartBusinessService = shoppingCartBusinessService;
            _commentBusinessService = commentBusinessService;
        }

        [Route("Products")]
        public IActionResult Index()
        {
            ProductViewModel productViewModel = new ProductViewModel();

            List<Product> products = _productBusinessService.GetAllWithBrand();
            List<Categories> categories = _categoriesBusinessService.GetAllWithSubCategories();

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
                                           BrandId = b.Key.Id,
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
                                           BrandId = b.Key.Id,
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
                                           BrandId = b.Key.Id,
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
            List<ProductProperties> productProperties = _productPropertiesBusinessService.GetAllByProductTypeCode(productTypeCode);

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
                                           BrandId = b.Key.Id,
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

            productViewModel.ProductTypeProperties = productProperties.Select(x => new ProductPropertyFilterModel
            {
                Id = x.Id,
                Property = x.Property,
                Values = x.ProductPropertyValues.Select(y => y.Value).Distinct().ToList()
            }).ToList();

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
                ProductTypeCode = product.BrandModel.ProductType.Code,
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

        [HttpPost]
        public ActionResult GetProducts(FilterModel filterModel, string categoryCode, string subCategoryCode, string productTypeCode, int pageNumber)
        {
            string itemsParPage = _iConfig.GetSection("ItemsPerPage").Value;

            List<Product> products = _productBusinessService.GetAllWithBrandByProductType(filterModel, categoryCode, subCategoryCode, productTypeCode, pageNumber, int.Parse(itemsParPage));

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
                Url = string.Format("{0}://{1}/Products/{2}/{3}/{4}/{5}", Request.Scheme, Request.Host, x.BrandModel.ProductType.SubCategory.Category.Code, x.BrandModel.ProductType.SubCategory.Code,
                  x.BrandModel.ProductType.Code,
                  x.Id)
            }).ToList();
            return Json(new { Data = productViewModelList });
        }

        [HttpPost]
        public ActionResult GetProductsCount(FilterModel filterModel, string categoryCode, string subCategoryCode, string productTypeCode)
        {
            int productCount = _productBusinessService.Count(filterModel, categoryCode, subCategoryCode, productTypeCode);
            return Json(new { Data = productCount });
        }

        [HttpPost]
        public ActionResult AddToShoppingCart(int productId)
        {
            List<ShoppingCartItemModel> shoppingCarts = new List<ShoppingCartItemModel>();

            Product product = _productBusinessService.GetByIdWithDetails(productId);
            ShoppingCartItemModel shoppingCartItem = new ShoppingCartItemModel
            {
                Id = product.Id,
                Name = $"{product.BrandModel.Brand.Name} {product.BrandModel.Name}",
                Price = product.Price,
                Quantity = 1
            };

            if (HttpContext.Session.Get<List<ShoppingCartItemModel>>("ShoppingCart") != null)
            {
                shoppingCarts = HttpContext.Session.Get<List<ShoppingCartItemModel>>("ShoppingCart");
                if (shoppingCarts.Any(x => x.Id == productId))
                {
                    shoppingCarts.First(x => x.Id == productId).Quantity++;
                }
                else
                {
                    shoppingCarts.Add(shoppingCartItem);
                }
                HttpContext.Session.Set<List<ShoppingCartItemModel>>("ShoppingCart", shoppingCarts);
            }
            else
            {
                shoppingCarts.Add(shoppingCartItem);
                HttpContext.Session.Set<List<ShoppingCartItemModel>>("ShoppingCart", shoppingCarts);
            }

            if (HttpContext.Session.Get<UserContext>("UserContext") != default)
            {
                UserContext userContext = HttpContext.Session.Get<UserContext>("UserContext");

                List<ShoppingCart> currentShoppingCarts = shoppingCarts.Select(x => new ShoppingCart
                {
                    CustomerId = userContext.Id,
                    ProductId = x.Id,
                    Quantity = x.Quantity,
                    AddDate = DateTime.Now
                }).ToList();

                _shoppingCartBusinessService.UpdateShoppingCarts(userContext.Id, currentShoppingCarts);
            }
            return Json(new { Data = true });
        }

        [HttpPost]
        public IActionResult SaveComment(int productId, string commentText)
        {
            ResponseViewModel response = new ResponseViewModel();
            if (HttpContext.Session.Get<UserContext>("UserContext") == null)
            {
                response.IsSuccess = false;
                response.Message = "Yorum yazabilmek için oturum açmalısınız.";
                return Json(response);
            }

            UserContext userContext = HttpContext.Session.Get<UserContext>("UserContext");

            Comment comment = new Comment
            {
                ApprovedById = 1,
                ApprovedDate = DateTime.Now,
                CommentDate = DateTime.Now,
                CommentText = commentText,
                CustomerId = userContext.Id,
                IsApproved = true,
                ProductId = productId,
                Title = $"{userContext.Id} Kullanıcı Yorumu"
            };

            _commentBusinessService.Save(comment);

            response.IsSuccess = true;
            response.Message = "Yorumunuz başarıyla kaydedilmiştir.";

            return Json(response);
        }
    }
}