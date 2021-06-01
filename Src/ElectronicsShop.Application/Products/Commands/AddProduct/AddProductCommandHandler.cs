using ElectronicsShop.Application.Common.Interfaces;
using ElectronicsShop.Application.Products.Commands.AddProduct.Dtos;
using ElectronicsShop.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElectronicsShop.Application.Products.Commands.AddProduct
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, AddProductOutput>
    {
        private readonly IProductRepository _productRepository;

        public AddProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<AddProductOutput> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            await _productRepository.CreateAsync(new Product { 
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                AvailableQuantity = request.AvailableQuantity,
                CategoryId = request.CategoryId,
                CreatedBy = request.CreatedBy,
                CreatedOn = DateTime.Now
            });

            return new AddProductOutput();
        }
    }
}
