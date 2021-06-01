using ElectronicsShop.Application.Users.Commands.Register.Dtos;
using MediatR;
using System;

namespace ElectronicsShop.Application.Users.Commands.Register
{
    public class RegisterCommand : IRequest<RegisterOutput>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
