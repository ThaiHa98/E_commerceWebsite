using Shared.DTOs;
using Shared.DTOs.RolePermission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceWebsite.Application.Common.Interfaces
{
    public interface IRolePermissionsRepository
    {
        Task<string> CreateAsync(CreateRolePermissionDto request);
    }
}
