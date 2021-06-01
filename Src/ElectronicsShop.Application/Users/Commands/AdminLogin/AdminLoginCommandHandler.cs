using ElectronicsShop.Application.Common.Interfaces;
using ElectronicsShop.Application.Users.Commands.AdminLogin.Dtos;
using MediatR;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElectronicsShop.Application.Users.Commands.AdminLogin
{
    public class AdminLoginCommandHandler : IRequestHandler<AdminLoginCommand, AdminLoginOutput>
    {
        private readonly IUserRepository _userRepository;

        public AdminLoginCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<AdminLoginOutput> Handle(AdminLoginCommand request, CancellationToken cancellationToken)
        {
            var sha1 = new SHA1CryptoServiceProvider();

            var hashedPassword = Convert.ToBase64String(sha1.ComputeHash(Encoding.ASCII.GetBytes(request.Password)));

            var user = await _userRepository.LoginAdmin(request.Email, hashedPassword);

            if (user == null)
            {
                return new AdminLoginOutput
                {
                    Status = false
                };
            }

            return new AdminLoginOutput
            {
                Status = true,
                User = user
            };
        }
    }
}
