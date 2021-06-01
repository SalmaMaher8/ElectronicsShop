using ElectronicsShop.Application.Users.Commands.Login.Dtos;
using MediatR;

namespace ElectronicsShop.Application.Users.Commands.Login
{
    public class LoginCommand : IRequest<LoginOutput>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
