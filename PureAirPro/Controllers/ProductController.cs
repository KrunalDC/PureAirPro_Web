using Microsoft.AspNetCore.Mvc;
using PureAirPro.Models;
using System.Diagnostics;

namespace PureAirPro.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

       

        public IActionResult Product()
        {
            return View();
        }


       
    }
}
