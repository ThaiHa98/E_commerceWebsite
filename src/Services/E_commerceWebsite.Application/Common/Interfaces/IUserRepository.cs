using Shared.DTOs;
using Shared.SeedWork;

namespace E_commerceWebsite.Application.Common.Interfaces
{
    public interface IUserRepository
    {
        Task<string> InsertAsyncCustomer(CreateUserDto request);
        Task<string> InsertAsyncEmployee(CreateUserDto request);
        Task<string> UpdateAsync(UpdateUserDto entity);
        Task<string> DeletesAsync(Guid id);
        Task<Pagination<UserDto>> GetPaging(UserSearchDto request);
        Task<UserDto> GetById(string id);
        Task<IList<UserDto>> GetAllStoresAsync();
        Task<string> Login(LoginRequest loginRequest);
        Task<string> Logout(Guid GuidId);
    }
}
