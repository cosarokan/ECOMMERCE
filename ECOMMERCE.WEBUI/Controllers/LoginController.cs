using ECOMMERCE.CORE.BusinessServices;
using ECOMMERCE.CORE.Entities;
using ECOMMERCE.CORE.Models;
using ECOMMERCE.WEBUI.Models;
using ECOMMERCE.WEBUI.Notification;
using Microsoft.AspNetCore.Mvc;
using System;
using ECOMMERCE.WEBUI.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace ECOMMERCE.WEBUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly ICustomersBusinessService _customersBusinessService;
        private readonly IShoppingCartBusinessService _shoppingCartBusinessService;
        private readonly INotification _notification;
        public LoginController(ICustomersBusinessService customersBusinessService, IShoppingCartBusinessService shoppingCartBusinessService, INotification notification)
        {
            _customersBusinessService = customersBusinessService;
            _shoppingCartBusinessService = shoppingCartBusinessService;
            _notification = notification;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string emailAddress, string password)
        {
            ResponseModel<Customers> result = _customersBusinessService.Login(emailAddress, password);
            ResponseViewModel response = new ResponseViewModel
            {
                IsSuccess = result.IsSuccess,
                Message = result.Message
            };

            if (result.IsSuccess && result.Model != null && result.Model.IsActive)
            {
                UserContext model = new UserContext();
                model.Id = result.Model.Id;
                model.Name = result.Model.Name;
                model.Email = result.Model.Email;
                List<int> productIdList = new List<int>();
                foreach (var item in result.Model.Orders)
                {
                    productIdList.AddRange(item.OrderDetails.Select(x => x.ProductId).ToList());
                }
                model.OrderProductIds = productIdList;

                if (HttpContext.Session.Get<UserContext>("UserContext") == default)
                {
                    HttpContext.Session.Set<UserContext>("UserContext", model);
                }

                List<ShoppingCartItemModel> shoppingCartItemModels = HttpContext.Session.Get<List<ShoppingCartItemModel>>("ShoppingCart");
                List<ShoppingCart> currentShoppingCarts = new List<ShoppingCart>();
                if (shoppingCartItemModels != null)
                {
                    currentShoppingCarts = shoppingCartItemModels.Select(x => new ShoppingCart
                    {
                        CustomerId = model.Id,
                        ProductId = x.Id,
                        Quantity = x.Quantity,
                        AddDate = DateTime.Now,
                    }).ToList();
                }

                List<ShoppingCart> shoppingCarts = _shoppingCartBusinessService.GetAllByCustomerId(model.Id, currentShoppingCarts);
                if (shoppingCarts != null && shoppingCarts.Any())
                {
                    if (HttpContext.Session.Get<List<ShoppingCartItemModel>>("ShoppingCart") == default)
                    {
                        List<ShoppingCartItemModel> updatedShoppingCarts = shoppingCarts.Select(x => new ShoppingCartItemModel
                        {
                            Id = x.ProductId,
                            Name = $"{x.Product.BrandModel.Brand.Name} {x.Product.BrandModel.Name}",
                            Price = x.Product.Price,
                            Quantity = x.Quantity,
                            StockQuantity = x.Product.StockQuantity,
                        }).ToList();
                        HttpContext.Session.Set<List<ShoppingCartItemModel>>("ShoppingCart", updatedShoppingCarts);
                    }
                }

                return Json(response);
            }
            //pasif bir kullanıcı..
            if (!result.IsSuccess && result.Model != null && !result.Model.IsActive)
            {
                response.Message = "Aktivasyon kodu tekrar gönderilmiştir.";
                SendMail(emailAddress);
            }
            return Json(response);
        }

        [HttpPost]
        public ActionResult Logout()
        {
            if (HttpContext.Session.Get<UserContext>("UserContext") != null)
            {
                HttpContext.Session.Remove("UserContext");
            }
            return Json(new { Result = true });
        }

        [Route("Products/Activatation/{customerEmail}")]
        public ActionResult Activation(string customerEmail)
        {
            ResponseModel<object> result = _customersBusinessService.AcivateCustomerByEmailAddress(customerEmail);

            ResponseViewModel response = new ResponseViewModel
            {
                IsSuccess = result.IsSuccess,
                Message = result.Message
            };

            return View(response);
        }

        [HttpPost]
        public ActionResult SignIn(string name, string email, string password)
        {
            Customers customer = new Customers
            {
                Name = name,
                Email = email,
                Password = password,
                IsActive = false,
                CreatedDate = DateTime.Now,
                CityId = 34,
                DistrictId = 446
            };

            ResponseModel<object> result = _customersBusinessService.Save(customer);
            ResponseViewModel response = new ResponseViewModel
            {
                IsSuccess = result.IsSuccess,
                Message = result.Message
            };
            if (result.IsSuccess)
            {
                SendMail(email);
            }

            return Json(response);
        }

        public void SendMail(string email)
        {
            _notification.SendMessage(email, "Üyeliğinizi aktif etmek için linki tıklayınız: " + string.Format("{0}://{1}/Products/Activatation/{2}", Request.Scheme, Request.Host, email));
        }
    }
}