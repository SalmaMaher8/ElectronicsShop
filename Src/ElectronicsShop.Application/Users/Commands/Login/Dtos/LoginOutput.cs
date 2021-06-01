using ElectronicsShop.Domain.Models;

namespace ElectronicsShop.Application.Users.Commands.Login.Dtos
{
    public class LoginOutput
    {
        public bool Status { get; set; }
        public User User { get; set; }
    }
}
