using ElectronicsShop.Domain.Common;
using ElectronicsShop.Domain.Common.Enums;
using System;

namespace ElectronicsShop.Domain.Models
{
    public class ProductDiscount : Entity<int>
    {
        public int ConditionQuantity { get; set; }
        public decimal Value { get; set; }
        public DiscountType Type { get; set; }
        public DateTime ValidUntil { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
