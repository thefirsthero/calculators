using Calculators.Core.Models;

namespace Calculators.Core.Services
{
    public interface ICalculatorService
    {
        DiscountCalculationResult CalculateDiscount(DiscountCalculationInput input);
        List<string> GetAvailableCalculators();
    }
}