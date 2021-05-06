using Microsoft.AspNetCore.Mvc;

namespace ECOMMERCE.WEBUI.Controllers
{
    public class Products: Controller
    {
        [Route("Products")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("Products/{category}")]
        public IActionResult Index(string category)
        {
            return View();
        }

        [Route("Products/{category}/{subCategory}")]
        public IActionResult Index(string category, string subCategory)
        {
            return View();
        }

        [Route("Products/{category}/{subCategory}/{productType}")]
        public IActionResult Index(string category, string subCategory, string productType)
        {
            return View();
        }

        [Route("Products/{category}/{subCategory}/{productType}/{productId}")]
        public IActionResult Detail(string category, string subCategory, string productType, string productId)
        {
            return View();
        }
    }
}

//http://asdasd.com/Products/Bilgisayar/Notebook/Oyun-Bilgisayari/HP1238798
