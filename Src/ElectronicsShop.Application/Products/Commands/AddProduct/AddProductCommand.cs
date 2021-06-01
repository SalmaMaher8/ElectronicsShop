using ElectronicsShop.Application.Products.Commands.AddProduct.Dtos;
using MediatR;

namespace ElectronicsShop.Application.Products.Commands.AddProduct
{
    public class AddProductCommand : IRequest<AddProductOutput>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int AvailableQuantity { get; set; }
        public int CreatedBy { get; set; }
        public int CategoryId { get; set; }
    }
}
