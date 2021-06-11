using Microsoft.AspNetCore.Mvc;

namespace ECOMMERCE.WEBUI.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
