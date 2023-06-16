using BLL;
using BTC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BTC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            ProductBLL p = new ProductBLL();
            return View("Index", p.Read());
            //return View("Index");
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
        public IActionResult ShowAll()
        {
            ProductBLL p = new ProductBLL();
            return View("Show", p.Read());

        }
        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult HowToUse()
        {
            return View();
        }
        public IActionResult ContactUs()
        {
            return View();
        }

    }
}