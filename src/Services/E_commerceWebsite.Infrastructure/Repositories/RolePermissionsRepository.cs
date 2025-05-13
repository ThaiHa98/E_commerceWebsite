using E_commerceWebsite.Application.Common.Interfaces;
using E_commerceWebsite.Domain.Entities;
using E_commerceWebsite.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Shared.Common.Constants;
using Shared.DTOs.RolePermission;
using Serilog;


namespace E_commerceWebsite.Infrastructure.Repositories
{
    public class RolePermissionsRepository : IRolePermissionsRepository
    {
        private readonly E_commerceWebsiteDbContext _dbContext;
        private readonly ILogger _logger;
        private static string Methods = "RolePermissionsRepository";
        public RolePermissionsRepository(E_commerceWebsiteDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public async Task<string> CreateAsync(CreateRolePermissionDto request)
        {
            try
            {
                var role = await _dbContext.Roles.FirstOrDefaultAsync(r => r.GuidId == request.Role_GuidId);
                if (role == null)
                {
                    return $"{request.Role_GuidId} not found";
                }
                var permission = await _dbContext.Permissions.FirstOrDefaultAsync(p => p.GuidId == request.Permission_GuidId);
                if (permission == null)
                {
                    return $"{request.Permission_GuidId} not found";
                }
                var rolePermission = new RolePermissions
                {
                    GuidId = Guid.NewGuid(),
                    Role_Id = role.GuidId,
                    Role_Name = role.Name,
                    Permission_Id = permission.GuidId,
                    CommandCode = permission.Name,
                    FunctionCode = role.Name
                };
                _dbContext.RolePermissions.Add(rolePermission);
                var result = await _dbContext.SaveChangesAsync();
                return result > 0 ? MessageConstants.CREATED_OK_MSG : MessageConstants.CREATED_ERR_MSG;
            }
            catch (Exception ex)
            {
                _logger.Error($"Exception {Methods} {nameof(CreateAsync)}: {ex.Message}");
                return ex.Message;
            }
        }
    }
}
