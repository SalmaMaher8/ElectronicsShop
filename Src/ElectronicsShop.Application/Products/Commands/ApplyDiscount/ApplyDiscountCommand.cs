using ElectronicsShop.Application.Products.Commands.ApplyDiscount.Dtos;
using ElectronicsShop.Domain.Common.Enums;
using MediatR;
using System;

namespace ElectronicsShop.Application.Products.Commands.ApplyDiscount
{
    public class ApplyDiscountCommand : IRequest<ApplyDiscountOutput>
    {
        public int ConditionQuantity { get; set; }
        public decimal Value { get; set; }
        public DiscountType Type { get; set; }
        public DateTime ValidUntil { get; set; }
        public int ProductId { get; set; }
    }
}
