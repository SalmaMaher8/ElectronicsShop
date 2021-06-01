using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ElectronicsShop.Presentation.ViewModels
{
    public class UserVM
    {
        public int Id { get; set; }

        [Display(Name = "User Name")]
        [Required(ErrorMessage = "User Name is Required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }

        [Compare("Password")]
        [Required(ErrorMessage = "Confirm Password is Required")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is Required")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Address is Required")]
        public string Address { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number is Required")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Birth Date")]
        [Required(ErrorMessage = "Birth Date is Required")]
        public DateTime BirthDate { get; set; }
        public IEnumerable<UserRoleVM> UserRoles { get; set; }
    }
}
