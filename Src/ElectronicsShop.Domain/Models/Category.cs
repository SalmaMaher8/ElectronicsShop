using ElectronicsShop.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicsShop.Domain.Models
{
    public class Category : Entity<int>
    {
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
