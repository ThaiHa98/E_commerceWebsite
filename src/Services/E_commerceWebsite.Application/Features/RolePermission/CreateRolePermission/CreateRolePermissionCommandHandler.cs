using E_commerceWebsite.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceWebsite.Application.Features.RolePermission.CreateRolePermission
{
    public class CreateRolePermissionCommandHandler : IRequestHandler<CreateRolePermissionCommand, string>
    {
        private readonly IRolePermissionsRepository _rolePermissionsRepository;
        public CreateRolePermissionCommandHandler(IRolePermissionsRepository rolePermissionsRepository) 
        {
            _rolePermissionsRepository = rolePermissionsRepository;
        }
        public async Task<string> Handle(CreateRolePermissionCommand request, CancellationToken cancellationToken)
        {
            var rolePermission = await _rolePermissionsRepository.CreateAsync(request.Entity);

            return rolePermission;
        }
    }
}
