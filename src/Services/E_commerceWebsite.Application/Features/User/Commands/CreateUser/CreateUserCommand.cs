using MediatR;
using Shared.DTOs;
using Shared.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceWebsite.Application.Features.User.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<string>
    {
        public CreateUserCustomerDto Entity { get; private set; }

        public CreateUserCommand(CreateUserCustomerDto entity) 
        {
            Entity = entity;
        }
    }
}
