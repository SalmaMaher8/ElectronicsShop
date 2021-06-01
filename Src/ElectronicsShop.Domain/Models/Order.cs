using ElectronicsShop.Domain.Common;
using System;
using System.Collections.Generic;

namespace ElectronicsShop.Domain.Models
{
    public class Order : Entity<int>
    {
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
