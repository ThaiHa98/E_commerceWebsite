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
    public class RolesRepositories : IRolesRepository
    {
        #region Fields
        private readonly E_commerceWebsiteDbContext _dbContext;
        private readonly ILogger _logger;
        private static string Methods = "RolesRepositories";
        #endregion

        #region Ctor
        public RolesRepositories(E_commerceWebsiteDbContext dbContext, ILogger logger) 
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        #endregion

        #region Methods
        public async Task<string> CreateAsync(CreateRolesDto request)
        {
            try
            {
                if (request == null)
                {
                    return $"Create Role without all data fields filled";
                }
                var createRoles = new Roles
                {
                    GuidId = Guid.NewGuid(),
                    Name = request.Name,
                    Description = request.Description,
                };
                _dbContext.Roles.Add(createRoles);
                var result = await _dbContext.SaveChangesAsync();
                return result > 0 ? MessageConstants.CREATED_OK_MSG : MessageConstants.CREATED_ERR_MSG;
            }
            catch (Exception ex) 
            {
                _logger.Error($"Exception {Methods} {nameof(CreateAsync)}: {ex.Message}");
                return ex.Message;
            }
        }

        public async Task<string> DeletesAsync(Guid id)
        {
            try
            {
                var roles = await _dbContext.Roles.FirstOrDefaultAsync(r => r.GuidId == id);
                if (roles == null)
                {
                    return $"roles Id not found";
                }
                _dbContext.Remove(roles);
                var result = await _dbContext.SaveChangesAsync();
                return result > 0 ? MessageConstants.DELETED_OK_MSG : MessageConstants.DELETED_ERR_MSG;
            }
            catch (Exception ex)
            {
                {
                    _logger.Error($"Exception {Methods} {nameof(DeletesAsync)}: {ex.Message}");
                    return ex.Message;
                }
            }
        }

        public async Task<RolesDto> GetById(string id)
        {
            try
            {
                if (!Guid.TryParse(id, out Guid guidId))
                {
                    _logger.Warning($"Invalid Guid format: {id}");
                    return null;
                }

                var role = await _dbContext.Roles
                    .AsNoTracking()
                    .FirstOrDefaultAsync(r => r.GuidId == guidId);

                if (role == null)
                {
                    return null;
                }

                return new RolesDto
                {
                    GuidId = role.GuidId,
                    Name = role.Name,
                    Description = role.Description
                };
            }
            catch (Exception ex)
            {
                _logger.Error($"Exception in {nameof(GetById)}: {ex.Message}");
                return null;
            }
        }

        public async Task<Pagination<RolesDto>> GetPaging(RolesSearchDto request)
        {
            try
            {
                request.Keywords = request.Keywords?.Trim();

                var query = _dbContext.Roles
                    .AsNoTracking()

                    .Where(x => string.IsNullOrEmpty(request.Keywords)
                        || x.Name.Contains(request.Keywords)
                        || x.Description.Contains(request.Keywords))
                    .Select(x => new RolesDto
                    {
                        GuidId = x.GuidId,
                        Name = x.Name,
                        Description = x.Description
                    });

                var totalRecords = await query.CountAsync();

                var paginatedList = await query
                    .Skip((request.PageIndex - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync();

                return new Pagination<RolesDto>
                {
                    Items = paginatedList,
                    TotalRecords = totalRecords
                };
            }
            catch (Exception ex)
            {
                _logger.Information($"Exception {nameof(GetPaging)} error: {ex.Message}");
                return new Pagination<RolesDto>();
            }
        }

        public async Task<string> UpdateAsync(UpdateRolesDto entity)
        {
            try
            {
                var roles = await _dbContext.Roles.FirstOrDefaultAsync(r => r.GuidId == entity.GuidId);
                if(roles  == null)
                {
                    return $"roles Id not found";
                }
                roles.Name = entity.Name;
                roles.Description = entity.Description;

                var result = await _dbContext.SaveChangesAsync();
                if(result > 0)
                {
                    return MessageConstants.UPDATED_OK_MSG;
                }
                return MessageConstants.UPDATED_ERR_MSG;
            }
            catch (Exception ex)
            {
                _logger.Error($"Exception in {nameof(UpdateAsync)}: {ex.Message}");
                return null;
            }

        }
        #endregion
    }
}
