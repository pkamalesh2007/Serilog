using Microsoft.AspNetCore.Mvc;
using SerliogDemo.Models;
using System.Diagnostics;
using Serilog;

namespace SerliogDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly Serilog.ILogger _logger;

        public HomeController(Serilog.ILogger logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.Information("The Applictaion Starts here in the Index");
             return View();
        }

        public IActionResult Privacy()
        {
            _logger.Information("The Applictaion Starts here in the Privacy");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}