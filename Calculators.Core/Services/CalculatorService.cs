using Calculators.Core.Calculators;
using Calculators.Core.Models;
using Calculators.Core.Services;

namespace Calculators.Core.Services
{
    public class CalculatorService : ICalculatorService
    {
        private readonly DiscountCalculator _discountCalculator;

        public CalculatorService()
        {
            _discountCalculator = new DiscountCalculator();
        }

        public DiscountCalculationResult CalculateDiscount(DiscountCalculationInput input)
        {
            try
            {
                return _discountCalculator.Calculate(input);
            }
            catch (Exception ex)
            {
                // Log the exception here if you have logging configured
                throw new InvalidOperationException("Error calculating discount", ex);
            }
        }

        public List<string> GetAvailableCalculators()
        {
            return new List<string>
            {
                "Discount Calculator",
                "Currency Converter (Coming Soon)",
                "Unit Converter (Coming Soon)",
                "Percentage Calculator (Coming Soon)",
                "VAT Calculator (Coming Soon)",
                "Fuel Efficiency Calculator (Coming Soon)"
            };
        }
    }
}