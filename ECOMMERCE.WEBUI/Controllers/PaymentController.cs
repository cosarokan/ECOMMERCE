using ECOMMERCE.CORE.BusinessServices;
using ECOMMERCE.CORE.Entities;
using ECOMMERCE.WEBUI.Extensions;
using ECOMMERCE.WEBUI.Models;
using ECOMMERCE.WEBUI.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ECOMMERCE.WEBUI.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IOrdersBusinessService _ordersBusinessService;
        private readonly ICityBusinessService _cityBusinessService;
        private readonly IDistrictBusinessService _districtBusinessService;
        public PaymentController(IOrdersBusinessService ordersBusinessService, ICityBusinessService cityBusinessService, IDistrictBusinessService districtBusinessService)
        {
            _ordersBusinessService = ordersBusinessService;
            _cityBusinessService = cityBusinessService;
            _districtBusinessService = districtBusinessService;
        }
        public IActionResult Index()
        {
            List<City> cities = _cityBusinessService.GetAll();
            List<CityModels> cityModels = new List<CityModels>();
            foreach (var cityItem in cities)
            {
                CityModels cityModel = new CityModels();
                cityModel.Id = cityItem.Id;
                cityModel.Name = cityItem.Name;
                cityModels.Add(cityModel);
            }

            PaymentViewModel paymentViewModel = new PaymentViewModel();
            paymentViewModel.Cities = cityModels;
            return View(paymentViewModel);
        }

        [HttpPost]
        public IActionResult Pay()
        {
            ResponseViewModel responseViewModel = new ResponseViewModel();
            if (HttpContext.Session.Get<UserContext>("UserContext") == null)
            {
                responseViewModel.IsSuccess = false;
                responseViewModel.Message = "Ödeme yapmak için giriş yapınız.";
                return Json(responseViewModel);
            }

            if (HttpContext.Session.Get<List<ShoppingCartItemModel>>("ShoppingCart") != null)
            {
                UserContext userContext = HttpContext.Session.Get<UserContext>("UserContext");
                List<ShoppingCartItemModel> shoppingCartItems = HttpContext.Session.Get<List<ShoppingCartItemModel>>("ShoppingCart");

                List<ShoppingCart> shoppingCarts = shoppingCartItems.Select(x => new ShoppingCart
                {
                    AddDate = DateTime.Now,
                    CustomerId = userContext.Id,
                    ProductId = x.Id,
                    Quantity = x.Quantity
                }).ToList();

                _ordersBusinessService.CreateOrder(userContext.Id, shoppingCarts);

                HttpContext.Session.Set<List<ShoppingCartItemModel>>("ShoppingCart", null);
            }
            return Json(new { Data = true });
        }

        [HttpPost]
        public IActionResult GetDistrictsByCityId(int cityId)
        {
            List<District> districts =  _districtBusinessService.GetAllByCityId(cityId);
            List<DistrictModel> districtModels = districts.Select(x => new DistrictModel
            {
                CityId = x.CityId,
                Id = x.Id,
                Name = x.Name
            }).ToList();

            return Json(new { Data = districts });
        }

        [Route("PaymentSuccessful")]
        public IActionResult PaymentSuccessful()
        {
            return View();
        }
    }
}
