using ECOMMERCE.CORE.BusinessServices;
using ECOMMERCE.CORE.Entities;
using ECOMMERCE.WEBUI.Notification;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ECOMMERCE.WEBUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly ICustomersBusinessService _customersBusinessService;
        private readonly INotification _notification;
        public LoginController(ICustomersBusinessService customersBusinessService, INotification notification)
        {
            _customersBusinessService = customersBusinessService;
            _notification = notification;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Route("Products/Activatation/{customerEmail}")]
        public ActionResult Activation(string customerEmail)
        {
            return View();
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

            _customersBusinessService.Save(customer);

            _notification.SendMessage(customer.Email, "Üyeliğinizi aktif etmek için linki tıklayınız: " + string.Format("{0}://{1}/Products/Activatation/{2}", Request.Scheme, Request.Host, email));
            return Json(new { Result = true });
        }
    }
}