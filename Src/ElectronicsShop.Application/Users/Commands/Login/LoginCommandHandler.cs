using ElectronicsShop.Application.Common.Interfaces;
using ElectronicsShop.Application.Users.Commands.Login.Dtos;
using MediatR;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElectronicsShop.Application.Users.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginOutput>
    {
        private readonly IUserRepository _userRepository;

        public LoginCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<LoginOutput> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var sha1 = new SHA1CryptoServiceProvider();

            var hashedPassword = Convert.ToBase64String(sha1.ComputeHash(Encoding.ASCII.GetBytes(request.Password)));

            var user = await _userRepository.LoginUser(request.Email, hashedPassword);

            if(user == null)
            {
                return new LoginOutput
                {
                    Status = false
                };
            }

            return new LoginOutput { 
                Status = true,
                User = user
            };
        }
    }
}
