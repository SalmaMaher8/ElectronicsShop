using ElectronicsShop.Domain.Models;
using System.Collections.Generic;

namespace ElectronicsShop.Application.Orders.Queries.GetOrders.Dtos
{
    public class GetOrdersOutput
    {
        public IEnumerable<Order> Orders { get; set; }
    }
}
