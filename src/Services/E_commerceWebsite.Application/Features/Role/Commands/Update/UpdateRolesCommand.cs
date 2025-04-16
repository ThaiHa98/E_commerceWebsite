using MediatR;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceWebsite.Application.Features.Role.Commands.Update
{
    public class UpdateRolesCommand : IRequest<string>
    {
        public UpdateRolesDto Entity { get; set; }
        public UpdateRolesCommand(UpdateRolesDto entity) 
        {
            Entity = entity;
        }
    }
}
