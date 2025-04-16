using E_commerceWebsite.Application.Common.Interfaces;
using E_commerceWebsite.Domain.Entities;
using E_commerceWebsite.Infrastructure.Persistence;
using Shared.Common.Constants;
using Shared.DTOs;
using Shared.SeedWork;
using Serilog;
using Microsoft.EntityFrameworkCore;

namespace E_commerceWebsite.Infrastructure.Repositories
{
    public class PermissionsRepositories : IPermissionsRepository
    {
        #region Fields
        private readonly E_commerceWebsiteDbContext _dbContext;
        private readonly ILogger _logger;
        private static string Methods = "RolesRepositories";
        #endregion

        #region Ctor
        public PermissionsRepositories(E_commerceWebsiteDbContext dbContext, ILogger logger)
        {
            _logger = logger;
            _dbContext = dbContext;
        }
        #endregion

        public async Task<string> CreateAsync(CreatePermissionsDto request)
        {
            try
            {
                if (request == null)
                {
                    return $"Create Permissions without all data fields filled";
                }
                var permissions = new Permissions
                {
                    GuidId = Guid.NewGuid(),
                    Name = request.Name,
                    Description = request.Description,
                };
                _dbContext.Permissions.Add(permissions);

                var role = await _dbContext.Roles.FirstOrDefaultAsync(r => r.GuidId == request.Role_Id);
                if (role == null)
                {
                    return $"Role with ID {request.Role_Id} not found";
                }
                var rolePermissions = new RolePermissions
                {
                    GuidId = Guid.NewGuid(),
                    Role_Id = role.GuidId,
                    Role_Name = role.Name,
                    Permission_Id = permissions.GuidId,
                    FunctionCode = request.FunctionCode,
                    CommandCode = permissions.Name,
                };

                _dbContext.RolePermissions.Add(rolePermissions);
                var result = await _dbContext.SaveChangesAsync();
                return result > 0 ? MessageConstants.CREATED_OK_MSG : MessageConstants.CREATED_ERR_MSG;
            }
            catch (Exception ex)
            {
                _logger.Error($"Exception {Methods} {nameof(CreateAsync)}: {ex.Message}");
                return ex.Message;
            }

        }

        public Task<string> DeletesAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PermissionsDto> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Pagination<PermissionsDto>> GetPaging(PermissionsSearchDto request)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateAsync(UpdatePermissionsDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
