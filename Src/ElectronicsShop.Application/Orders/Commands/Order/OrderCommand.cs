using ElectronicsShop.Application.Orders.Commands.Order.Dtos;
using MediatR;

namespace ElectronicsShop.Application.Orders.Commands.Order
{
    public class OrderCommand : IRequest<OrderOutput>
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int UserId { get; set; }
    }
}
