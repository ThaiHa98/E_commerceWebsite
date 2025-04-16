using Shared.DTOs;
using Shared.SeedWork;

namespace E_commerceWebsite.Application.Common.Interfaces
{
    public interface IPermissionsRepository
    {
        Task<string> CreateAsync(CreatePermissionsDto request);
        Task<string> UpdateAsync(UpdatePermissionsDto entity);
        Task<string> DeletesAsync(Guid id);
        Task<Pagination<PermissionsDto>> GetPaging(PermissionsSearchDto request);
        Task<PermissionsDto> GetById(string id);

    }
}
