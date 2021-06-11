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
    public class ShoppingCartController : Controller
    {
        private readonly IProductBusinessService _productBusinessService;
        private readonly IShoppingCartBusinessService _shoppingCartBusinessService;
        public ShoppingCartController(IProductBusinessService productBusinessService, IShoppingCartBusinessService shoppingCartBusinessService)
        {
            _productBusinessService = productBusinessService;
            _shoppingCartBusinessService = shoppingCartBusinessService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UpdateShoppingCart(int productId, int quantity)
        {
            List<ShoppingCartItemModel> shoppingCarts = new List<ShoppingCartItemModel>();

            if (HttpContext.Session.Get<List<ShoppingCartItemModel>>("ShoppingCart") != null)
            {
                shoppingCarts = HttpContext.Session.Get<List<ShoppingCartItemModel>>("ShoppingCart");
                shoppingCarts.First(x => x.Id == productId).Quantity = quantity;
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

        public IActionResult RemoveFromShoppingCart(int productId)
        {
            List<ShoppingCartItemModel> shoppingCarts = new List<ShoppingCartItemModel>();

            if (HttpContext.Session.Get<List<ShoppingCartItemModel>>("ShoppingCart") != null)
            {
                shoppingCarts = HttpContext.Session.Get<List<ShoppingCartItemModel>>("ShoppingCart");
                shoppingCarts.RemoveAll(x => x.Id == productId);
                HttpContext.Session.Set<List<ShoppingCartItemModel>>("ShoppingCart", shoppingCarts);
            }

            if (HttpContext.Session.Get<UserContext>("UserContext") != default)
            {
                UserContext userContext = HttpContext.Session.Get<UserContext>("UserContext");

                _shoppingCartBusinessService.RemoveFromShoppingCart(userContext.Id, productId);
            }
            return Json(new { Data = true });
        }
    }
}
