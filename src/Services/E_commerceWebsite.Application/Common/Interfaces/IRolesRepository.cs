using Shared.DTOs;
using Shared.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceWebsite.Application.Common.Interfaces
{
    public interface IRolesRepository
    {
        Task<string> CreateAsync(CreateRolesDto request);
        Task<string> UpdateAsync(UpdateRolesDto entity);
        Task<string> DeletesAsync(Guid id);
        Task<Pagination<RolesDto>> GetPaging(RolesSearchDto request);
        Task<RolesDto> GetById(string id);

    }
}
