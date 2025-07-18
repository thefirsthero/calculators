using Calculators.Core.Models;

namespace Calculators.Web.Models
{
    public class DiscountCalculatorViewModel
    {
        public DiscountCalculationInput Input { get; set; } = new();
        public DiscountCalculationResult? Result { get; set; }
    }
}