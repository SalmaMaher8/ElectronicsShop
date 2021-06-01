using ElectronicsShop.Application.Common.Interfaces;
using ElectronicsShop.Application.Products.Queries.GetProducts.Dtos;
using ElectronicsShop.Domain.Models;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ElectronicsShop.Application.Products.Queries.GetProducts
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, GetProductsOutput>
    {
        private readonly IProductRepository _productRepository;

        public GetProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<GetProductsOutput> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetCategoryProductsAsync(request.CategoryId);

            return new GetProductsOutput {
                Products = products
            };
        }
    }
}
