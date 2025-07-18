using Calculators.Core.Services;
using Calculators.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Calculators.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICalculatorService _calculatorService;

        public HomeController(ILogger<HomeController> logger, ICalculatorService calculatorService)
        {
            _logger = logger;
            _calculatorService = calculatorService;
        }

        public IActionResult Index()
        {
            var availableCalculators = _calculatorService.GetAvailableCalculators();
            return View(availableCalculators);
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