using ElectronicsShop.Domain.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace ElectronicsShop.Presentation.ViewModels
{
    public class ProductDiscountVM
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        [Display(Name = "Condition Quantity")]
        public int ConditionQuantity { get; set; }
        public decimal Value { get; set; }
        public DiscountType Type { get; set; }

        [Display(Name = "Valid Until")]
        public DateTime ValidUntil { get; set; }
    }
}
