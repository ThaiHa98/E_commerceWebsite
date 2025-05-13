using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs.RolePermission
{
    public class CreateRolePermissionDto
    {
        public Guid Role_GuidId { get; set; }
        public Guid Permission_GuidId { get; set; }
    }
}
