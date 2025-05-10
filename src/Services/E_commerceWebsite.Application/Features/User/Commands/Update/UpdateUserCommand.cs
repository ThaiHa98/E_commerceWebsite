using MediatR;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceWebsite.Application.Features.User.Commands.Update
{
    public class UpdateUserCommand : IRequest<string>
    {
        public UpdateUserDto Entity { get; set; }
        public UpdateUserCommand(UpdateUserDto entity)
        {
            Entity = entity;
        }
    }
}
