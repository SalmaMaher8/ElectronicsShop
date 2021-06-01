using ElectronicsShop.Domain.Common;

namespace ElectronicsShop.Domain.Models
{
    public class OrderDetail : Entity<int>
    {
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
