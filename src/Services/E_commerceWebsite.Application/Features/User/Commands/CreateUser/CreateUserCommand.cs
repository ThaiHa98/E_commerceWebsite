using MediatR;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceWebsite.Application.Features.User.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<string>
    {
        public CreateUserDto Entity { get; private set; }

        public CreateUserCommand(CreateUserDto entity) 
        {
            Entity = entity;
        }
    }
}
