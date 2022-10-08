using Core.Domain.Services;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portal.Models;
using System.Diagnostics;

namespace Portal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        private readonly PackageDbContext packageDbContext;

        public HomeController(ILogger<HomeController> logger, IPackageRepository packageRepository, PackageDbContext packageDbContext )
        {
            _logger = logger;
           
            this.packageDbContext = packageDbContext;
        }
       
       

        public IActionResult Index()
        {
            return View();
        }

       
        

        public IActionResult Vision()
        {
            return View();
        }

        public IActionResult Locations()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult ReservedBoxes()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

      
       
}
}