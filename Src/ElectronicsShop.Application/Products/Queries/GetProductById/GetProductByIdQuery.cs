using ElectronicsShop.Application.Products.Queries.GetProductById.Dtos;
using MediatR;

namespace ElectronicsShop.Application.Products.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<GetProductByIdOutput>
    {
        public int Id { get; set; }
    }
}
