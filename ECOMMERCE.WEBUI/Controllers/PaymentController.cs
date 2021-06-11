using ECOMMERCE.CORE.BusinessServices;
using ECOMMERCE.CORE.Entities;
using ECOMMERCE.WEBUI.Extensions;
using ECOMMERCE.WEBUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ECOMMERCE.WEBUI.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IOrdersBusinessService _ordersBusinessService;
        public PaymentController(IOrdersBusinessService ordersBusinessService)
        {
            _ordersBusinessService = ordersBusinessService;
        }
        public IActionResult Index()
        {
            return View();
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

        [Route("PaymentSuccessful")]
        public IActionResult PaymentSuccessful()
        {
            return View();
        }
    }
}
