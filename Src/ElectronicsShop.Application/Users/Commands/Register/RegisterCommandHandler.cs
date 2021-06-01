using ElectronicsShop.Application.Common.Interfaces;
using ElectronicsShop.Application.Users.Commands.Register.Dtos;
using ElectronicsShop.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElectronicsShop.Application.Users.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterOutput>
    {
        private readonly IUserRepository _userRepository;

        public RegisterCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<RegisterOutput> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var sha1 = new SHA1CryptoServiceProvider();

            var hashedPassword = sha1.ComputeHash(Encoding.ASCII.GetBytes(request.Password));

            var user = await _userRepository.CreateAsync(new User { 
                UserName = request.UserName,
                FullName = request.FullName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Address = request.Address,
                Password = Convert.ToBase64String(hashedPassword),
                UserRoles = new List<UserRole> { new UserRole { 
                    RoleId = 2
                } }
            });

            return new RegisterOutput { 
                User = user
            };
        }
    }
}
