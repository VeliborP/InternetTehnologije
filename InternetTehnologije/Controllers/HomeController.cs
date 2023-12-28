using InternetTehnologije.DAL;
using InternetTehnologije.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace InternetTehnologije.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly InternetTehnologijeContext _context;

        public HomeController(ILogger<HomeController> logger, InternetTehnologijeContext context)
        {
            _logger = logger;
            _context = context;
        }

        public JsonResult Test()
        {
            return Json(_context.Predmets.ToList());
        }

        public IActionResult Index()
        {
            return View();
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
    }
}
