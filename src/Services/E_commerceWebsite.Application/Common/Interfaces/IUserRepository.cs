using Shared.DTOs;
using Shared.DTOs.User;
using Shared.SeedWork;

namespace E_commerceWebsite.Application.Common.Interfaces
{
    public interface IUserRepository
    {
        Task<string> InsertAsyncCustomer(CreateUserCustomerDto request);
        Task<string> InsertAsyncEmployee(CreateUserDto request);
        Task<string> UpdateAsync(UpdateUserDto entity);
        Task<string> DeletesAsync(Guid id);
        Task<Pagination<UserDto>> GetPaging(UserSearchDto request);
        Task<UserDto> GetById(Guid id);
        Task<string> Login(LoginRequest loginRequest);
        Task<string> Logout(Guid GuidId);
    }
}
