using MediatR;
using Shared.DTOs;

namespace E_commerceWebsite.Application.Features.User.Commands.Login
{
    public class LoginCommand : IRequest<string>
    {
        public LoginRequest Entity { get; set; }
        public LoginCommand(LoginRequest entity) 
        {
            Entity = entity;
        }
    }
}
