using System;
using System.ComponentModel.DataAnnotations;

namespace ElectronicsShop.Presentation.ViewModels
{
    public class ProductVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is Required")]
        public string Description { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Price is Required")]
        [Range(0, int.MaxValue, ErrorMessage = "Price is Required")]
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        [Display(Name = "Available Quantity")]
        [Range(0, int.MaxValue, ErrorMessage = "Available Quantity is Required")]
        public int AvailableQuantity { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        [Display(Name = "Category")]
        [Range(1, int.MaxValue, ErrorMessage = "Category is Required")]
        public int CategoryId { get; set; }
    }
}
