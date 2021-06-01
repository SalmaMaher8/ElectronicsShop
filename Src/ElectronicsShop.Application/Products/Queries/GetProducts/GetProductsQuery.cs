using ElectronicsShop.Application.Products.Queries.GetProducts.Dtos;
using MediatR;

namespace ElectronicsShop.Application.Products.Queries.GetProducts
{
    public class GetProductsQuery : IRequest<GetProductsOutput>
    {
        public int CategoryId { get; set; }
    }
}
