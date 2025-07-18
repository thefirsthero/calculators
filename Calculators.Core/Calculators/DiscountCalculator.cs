using Calculators.Core.Interfaces;
using Calculators.Core.Models;

namespace Calculators.Core.Calculators
{
    public class DiscountCalculator : ICalculator<DiscountCalculationInput, DiscountCalculationResult>
    {
        public DiscountCalculationResult Calculate(DiscountCalculationInput input)
        {
            if (!IsValidInput(input))
                throw new ArgumentException("Invalid input provided");

            var discountAmount = (input.OriginalPrice * input.DiscountPercentage) / 100;
            var finalPrice = input.OriginalPrice - discountAmount;

            return new DiscountCalculationResult
            {
                OriginalPrice = input.OriginalPrice,
                DiscountPercentage = input.DiscountPercentage,
                DiscountAmount = Math.Round(discountAmount, 2),
                FinalPrice = Math.Round(finalPrice, 2),
                SavingsAmount = Math.Round(discountAmount, 2),
                CalculatedAt = DateTime.UtcNow
            };
        }

        public bool IsValidInput(DiscountCalculationInput input)
        {
            if (input == null) return false;
            if (input.OriginalPrice <= 0) return false;
            if (input.DiscountPercentage < 0 || input.DiscountPercentage > 100) return false;
            return true;
        }

        public string GetCalculatorName()
        {
            return "Discount Calculator";
        }
    }
}