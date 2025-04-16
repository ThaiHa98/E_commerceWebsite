using MediatR;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceWebsite.Application.Features.Permission.Commands.Create
{
    public class CreatePermissionsCommand : IRequest<string>
    {
        public CreatePermissionsDto Entity { get; private set; }
        public CreatePermissionsCommand(CreatePermissionsDto entity) 
        {
            Entity = entity;
        }
    }
}
