using ElectronicsShop.Domain.Common;

namespace ElectronicsShop.Domain.Models
{
    public class Role : Entity<int>
    {
        public string Name { get; set; }
    }
}
