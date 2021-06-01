using System.Collections.Generic;

namespace ElectronicsShop.Presentation.ViewModels
{
    public class CategoryVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<ProductVM> Products { get; set; }
    }
}
