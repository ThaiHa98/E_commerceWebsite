using MediatR;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceWebsite.Application.Features.User.Commands.CreateUserEmployee
{
    public class CreateUserEmployeeCommand : IRequest<string>
    {
        public CreateUserDto Entity { get; set; }

        public CreateUserEmployeeCommand( CreateUserDto entity ) 
        {
            Entity = entity;
        }
    }
}
