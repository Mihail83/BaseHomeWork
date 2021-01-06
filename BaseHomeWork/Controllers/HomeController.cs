using BaseHomeWork.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using BaseHomeWork.Filters;
using BaseHomeWork.DAL;
using Microsoft.Extensions.Configuration;

namespace BaseHomeWork.Controllers
{
    [SetUserNameAttribute]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;            
        }        

        public IActionResult Index(int CatalogID = 1)
        {
            var indexViewModelSupplier = new GetHomeIndexViewModel(_configuration);
            var indexViewModel = indexViewModelSupplier.GetByCatalogID(CatalogID);           
            return View(indexViewModel);
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(String name)
        {
            if (!String.IsNullOrWhiteSpace(name))
            {
                HttpContext.Response.Cookies.Append("User", name);
            }            
            return RedirectToAction("Login","Home");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
