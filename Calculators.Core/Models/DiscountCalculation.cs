using System.ComponentModel.DataAnnotations;

namespace Calculators.Core.Models
{
    public class DiscountCalculationInput
    {
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Original price must be greater than 0")]
        [Display(Name = "Original Price")]
        public decimal OriginalPrice { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "Discount percentage must be between 0 and 100")]
        [Display(Name = "Discount Percentage")]
        public decimal DiscountPercentage { get; set; }
    }

    public class DiscountCalculationResult
    {
        public decimal OriginalPrice { get; set; }
        public decimal DiscountPercentage { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal FinalPrice { get; set; }
        public decimal SavingsAmount { get; set; }
        public DateTime CalculatedAt { get; set; }
    }
}