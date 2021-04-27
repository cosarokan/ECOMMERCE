using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ECOMMERCE.WEBUI.Models;
using ECOMMERCE.CORE.BusinessServices;
using ECOMMERCE.CORE.Entities;
using System.Collections.Generic;
using System.Linq;
using ECOMMERCE.CORE.BusinessServices.Implementation;
using ECOMMERCE.DATA;

namespace ECOMMERCE.WEBUI.Controllers
{
    public class HomeController : Controller
    {
        //dependency injection..
        //1. constructor injection
        //2. property injection
        private readonly ICategoriesBusinessService _categoriesBusinessService;
        private readonly ISubCategoriesBusinessService _subCategoriesBusinessService;
        private readonly IProductPropertiesBusinessService _productPropertiesBusinessService;
        private readonly IProductBusinessService _productBusinessService;
        private readonly ICustomersBusinessService _customersBusinessService;
        private readonly IUsersBusinessService _usersBusinessService;
        private readonly IPaymentTypesBusinessService _paymentTypesBusinessService;
        private readonly IOrdersBusinessService _ordersBusinessService;
        private readonly ICommentBusinessService _commentBusinessService;
        private readonly IProductTypesBusinessService _productTypesBusinessService;
        private readonly ICityBusinessService _cityBusinessService;
        private readonly IDistrictBusinessService _districtBusinessService;
        private readonly INeighborhoodBusinessService _neighborhoodBusinessService;
        private readonly IBrandBusinessService _brandBusinessService;
        private readonly IBrandModelBusinessService _brandModelBusinessService;
        private readonly IShoppingCartBusinessService _shoppingCartBusinessService;
        private readonly IOrderStatusesBusinessService _orderStatusesBusinessService;

        public HomeController(ICategoriesBusinessService categoriesBusinessService, ISubCategoriesBusinessService subCategoriesBusinessService, 
            IProductPropertiesBusinessService productPropertiesBusinessService,
            IProductBusinessService productBusinessService, ICustomersBusinessService customersBusinessService, IUsersBusinessService usersBusinessService, IPaymentTypesBusinessService paymentTypesBusinessService, IOrdersBusinessService ordersBusinessService, ICommentBusinessService commentBusinessService, IProductTypesBusinessService productTypesBusinessService, ICityBusinessService cityBusinessService, IDistrictBusinessService districtBusinessService, INeighborhoodBusinessService neighborhoodBusinessService, IBrandBusinessService brandBusinessService, IBrandModelBusinessService brandModelBusinessService, IShoppingCartBusinessService shoppingCartBusinessService, IOrderStatusesBusinessService orderStatusesBusinessService)
        {
            _brandBusinessService = brandBusinessService;
            _brandModelBusinessService = brandModelBusinessService;
            _categoriesBusinessService = categoriesBusinessService;
            _subCategoriesBusinessService = subCategoriesBusinessService;
            _productPropertiesBusinessService = productPropertiesBusinessService;
            _productBusinessService = productBusinessService;
            _customersBusinessService = customersBusinessService;
            _usersBusinessService = usersBusinessService;
            _paymentTypesBusinessService = paymentTypesBusinessService;
            _ordersBusinessService = ordersBusinessService;
            _commentBusinessService = commentBusinessService;
            _productTypesBusinessService = productTypesBusinessService;
            _cityBusinessService = cityBusinessService;
            _districtBusinessService = districtBusinessService;
            _neighborhoodBusinessService = neighborhoodBusinessService;
            _shoppingCartBusinessService = shoppingCartBusinessService;
            _orderStatusesBusinessService = orderStatusesBusinessService;
        }

        public IActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel();
            List<Brands> brand = _brandBusinessService.GetAll();
            List<BrandModels> brandModels = _brandModelBusinessService.GetAll();
            List<Categories> categories = _categoriesBusinessService.GetAll();
            List<ProductProperties> productProperties = _productPropertiesBusinessService.GetAll();
            List<Product> product = _productBusinessService.GetAll();
            List<Customers> customers = _customersBusinessService.GetAll();
            List<Users> users = _usersBusinessService.GetAll();
            List<PaymentTypes> paymentTypes = _paymentTypesBusinessService.GetAll();
            List<Orders> orders = _ordersBusinessService.GetAll();
            List<Comment> comment = _commentBusinessService.GetAll();
            List<ProductTypes> productTypes = _productTypesBusinessService.GetAll();
            List<City> city = _cityBusinessService.GetAll();
            List<District> district = _districtBusinessService.GetAll();
            List<Neighborhood> neighborhood = _neighborhoodBusinessService.GetAll();
            List<ShoppingCart> shoppingCart = _shoppingCartBusinessService.GetAll();
            List<OrderStatuses> orderStatuses = _orderStatusesBusinessService.GetAll();


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
