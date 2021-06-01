using System.Collections.Generic;

namespace ElectronicsShop.Presentation.ViewModels
{
    public class ProductsListVM
    {
        public int CategoryId { get; set; }
        public IEnumerable<ProductVM> Products { get; set; }
    }
}
