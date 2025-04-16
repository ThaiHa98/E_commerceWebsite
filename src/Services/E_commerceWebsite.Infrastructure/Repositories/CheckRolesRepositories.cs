using E_commerceWebsite.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Shared.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceWebsite.Infrastructure.Repositories
{
    public class CheckRolesRepositories
    {
        private readonly E_commerceWebsiteDbContext _dbContext;

        public CheckRolesRepositories(E_commerceWebsiteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ApiResult<string>> GetPermissionsByUserIdAsync(Guid userId)
        {

            var userRoles = await _dbContext.UsersRoles
                .Where(ur => ur.User_Id == userId)
                .Select(ur => ur.Role_Id)
                .ToListAsync();

            var permissions = await _dbContext.RolePermissions
                .Where(rp => userRoles.Contains(rp.Role_Id))
                .Select(rp => rp.FunctionCode.Trim() + "_" + rp.CommandCode.Trim())
                .Distinct()
                .ToListAsync();

            var jsonPermissions = Newtonsoft.Json.JsonConvert.SerializeObject(permissions);


            return new ApiResult<string>
            {
                Success = true,
                Message = "Lấy quyền thành công",
                Data = jsonPermissions
            };
        }
    }
}
