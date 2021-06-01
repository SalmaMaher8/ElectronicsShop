using ElectronicsShop.Application.Common.Interfaces;
using ElectronicsShop.Application.Products.Commands.ApplyDiscount.Dtos;
using ElectronicsShop.Domain.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ElectronicsShop.Application.Products.Commands.ApplyDiscount
{
    public class ApplyDiscountCommandHandler : IRequestHandler<ApplyDiscountCommand, ApplyDiscountOutput>
    {
        private readonly IProductDiscountRepository _productDiscountRepository;

        public ApplyDiscountCommandHandler(IProductDiscountRepository productDiscountRepository)
        {
            _productDiscountRepository = productDiscountRepository;
        }

        public async Task<ApplyDiscountOutput> Handle(ApplyDiscountCommand request, CancellationToken cancellationToken)
        {
            await _productDiscountRepository.CreateAsync(new ProductDiscount {
                ProductId = request.ProductId,
                ConditionQuantity = request.ConditionQuantity,
                Type = request.Type,
                Value = request.Value,
                ValidUntil = request.ValidUntil
            });

            return new ApplyDiscountOutput();
        }
    }
}
