using MediatR;
using Shared.DTOs.RolePermission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceWebsite.Application.Features.RolePermission.CreateRolePermission
{
    public class CreateRolePermissionCommand : IRequest<string>
    {
        public CreateRolePermissionDto Entity { get; set; }
        public CreateRolePermissionCommand(CreateRolePermissionDto entity)
        {
            Entity = entity;
        }
    }
}
