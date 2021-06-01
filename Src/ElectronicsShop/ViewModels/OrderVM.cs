using System;
using System.Collections.Generic;

namespace ElectronicsShop.Presentation.ViewModels
{
    public class OrderVM
    {
        public int Id { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
        public UserVM User { get; set; }
        public IEnumerable<OrderDetailVM> OrderDetails { get; set; }
    }
}
