using Calculators.Core.Models;
using Calculators.Core.Services;
using Calculators.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Calculators.Web.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly ICalculatorService _calculatorService;
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ICalculatorService calculatorService, ILogger<CalculatorController> logger)
        {
            _calculatorService = calculatorService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var availableCalculators = _calculatorService.GetAvailableCalculators();
            return View(availableCalculators);
        }

        [HttpGet]
        public IActionResult Discount()
        {
            var viewModel = new DiscountCalculatorViewModel
            {
                Input = new DiscountCalculationInput(),
                Result = null
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Discount(DiscountCalculatorViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                model.Result = _calculatorService.CalculateDiscount(model.Input);
                ViewBag.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error calculating discount");
                ModelState.AddModelError("", "An error occurred while calculating the discount. Please try again.");
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult CalculateDiscountAjax([FromBody] DiscountCalculationInput input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
                }

                var result = _calculatorService.CalculateDiscount(input);
                return Json(new { success = true, result = result });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error calculating discount via AJAX");
                return Json(new { success = false, error = "An error occurred while calculating the discount." });
            }
        }
    }
}