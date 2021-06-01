using ElectronicsShop.Application.Common.Interfaces;
using ElectronicsShop.Application.Orders.Commands.Order.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElectronicsShop.Application.Orders.Commands.Order
{
    public class OrderCommandHandler : IRequestHandler<OrderCommand, OrderOutput>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public OrderCommandHandler(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public async Task<OrderOutput> Handle(OrderCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetAsync(request.ProductId);

            var order = await _orderRepository.CreateAsync(new Domain.Models.Order { 
                OrderDate = DateTime.Now,
                TotalAmount = product.Price * request.Quantity,
                UserId = request.UserId,
                OrderDetails = new List<Domain.Models.OrderDetail>() { 
                    new Domain.Models.OrderDetail{
                        ProductId = request.ProductId,
                        Quantity = request.Quantity
                    }
                }
            });
            
            if(order != null)
            {
                product.AvailableQuantity = product.AvailableQuantity - request.Quantity;

                await _productRepository.UpdateAsync(product);
            }

            return new OrderOutput();
        }
    }
}
