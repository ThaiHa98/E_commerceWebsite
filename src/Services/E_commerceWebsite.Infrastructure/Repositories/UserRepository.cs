using E_commerceWebsite.Application.Common.Interfaces;
using E_commerceWebsite.Infrastructure.Persistence;
using Shared.DTOs;
using Shared.SeedWork;
using Serilog;
using E_commerceWebsite.Domain.Entities;
using Shared.Common.Constants;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using E_commerceWebsite.Infrastructure.Helper;

namespace E_commerceWebsite.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        #region Fields
        private readonly E_commerceWebsiteDbContext _dbContext;
        private readonly ILogger _logger;
        private readonly Token _token;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private static string Methods = "UserRepository";
        #endregion

        #region Ctor
        public UserRepository(E_commerceWebsiteDbContext dbContext, ILogger logger, Token token, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _logger = logger;
            _token = token;
            _httpContextAccessor = httpContextAccessor;
        }
        #endregion

        #region Methods
        public Task<string> DeletesAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<UserDto>> GetAllStoresAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Pagination<UserDto>> GetPaging(UserSearchDto request)
        {
            throw new NotImplementedException();
        }

        public async Task<string> InsertAsyncCustomer(CreateUserDto request)
        {
            try
            {
                if (request == null)
                {
                    return "User not found";
                }
                var user = new User
                {
                    GuidId = Guid.NewGuid(),
                    Last_name = request.Last_name,
                    First_name = request.First_name,
                    Email = request.Email,
                    Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
                    Gender = request.Gender,
                    Phone = request.Phone,
                    Date_of_birth = request.Date_of_birth,
                    //Role = UserRole.Customer,
                    Date_Create = DateTime.Now,
                };
                _dbContext.Users.Add(user);
                var result = await _dbContext.SaveChangesAsync();
                return result > 0 ? MessageConstants.CREATED_OK_MSG : MessageConstants.CREATED_ERR_MSG;
            }
            catch (Exception ex)
            {
                _logger.Error($"Exception {Methods} {nameof(InsertAsyncCustomer)}: {ex.Message}");
                return ex.Message;
            }
        }

        public Task<string> UpdateAsync(UpdateUserDto entity)
        {
            throw new NotImplementedException();
        }

        public async Task<string> InsertAsyncEmployee(CreateUserDto request)
        {
            try
            {
                if (request == null)
                {
                    return "storeHeader not found";
                }
                var user = new User
                {
                    GuidId = Guid.NewGuid(),
                    Last_name = request.Last_name,
                    First_name = request.First_name,
                    Email = request.Email,
                    Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
                    Gender = request.Gender,
                    Phone = request.Phone,
                    Date_of_birth = request.Date_of_birth,
                    Date_Create = DateTime.Now,
                };
                _dbContext.Users.Add(user);

                var usRoles = await _dbContext.Roles.FirstOrDefaultAsync(ro => ro.GuidId == request.Role_Id);
                if (usRoles == null)
                {
                    return "usRoles not found";
                }
                var userRoles = new UserRoles
                {
                    GuidId = Guid.NewGuid(),
                    User_Id = user.GuidId,
                    User_Name = user.First_name + " " + user.Last_name,
                    Role_Id = usRoles.GuidId,
                    Role_Name = usRoles.Name,
                };
                _dbContext.UsersRoles.Add(userRoles);
                var result = await _dbContext.SaveChangesAsync();
                return result > 0 ? MessageConstants.CREATED_OK_MSG : MessageConstants.CREATED_ERR_MSG;
            }
            catch (Exception ex)
            {
                _logger.Error($"Exception {Methods} {nameof(InsertAsyncEmployee)}: {ex.Message}");
                return ex.Message;
            }
        }

        public async Task<string> Login(LoginRequest loginRequest)
        {
            try
            {
                if(loginRequest == null)
                {
                    return $"loginRequest has not been filled in with enough data";
                }
                var user = _dbContext.Users.FirstOrDefault(u => u.Email == loginRequest.Email);
                if(user == null)
                {
                    return $"Email not found";
                }
                if (!BCrypt.Net.BCrypt.Verify(loginRequest.Password, user.Password))
                {
                    return $"Incorrect password!";
                }

                string token = _token.CreateToken(user);

                var context = _httpContextAccessor.HttpContext;
                if (context != null)
                {
                    CookieOptions cookieOptions = new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true,
                        Expires = DateTime.Now.AddMinutes(60)
                    };
                    context.Response.Cookies.Append("authenticationToken", token, cookieOptions);

                    // Lưu thời gian truy cập cuối cùng của người dùng vào cookie
                    context.Response.Cookies.Append("lastActiveTime", DateTime.Now.ToString(), cookieOptions);
                }
                return await Task.FromResult(token);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while logging in", ex);
            }
        }

        public async Task<string> Logout(Guid guidId)
        {
            try
            {
                var context = _httpContextAccessor.HttpContext;

                if (context == null || !context.Request.Cookies.TryGetValue("authenticationToken", out var token))
                {
                    return "Token not found in cookies";
                }

                // Xác thực token
                if (!_token.ValidateToken(token))
                {
                    return "Invalid token";
                }

                // Lấy thông tin người dùng từ token
                var principal = _token.GetPrincipalFromToken(token);
                var tokenUserIdString = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (!Guid.TryParse(tokenUserIdString, out Guid tokenUserId))
                {
                    return "Invalid user ID in token";
                }

                if (tokenUserId != guidId)
                {
                    return "Token does not match the user ID";
                }

                // Xóa cookie
                context.Response.Cookies.Delete("authenticationToken");

                // Kiểm tra lại việc xóa cookie thành công
                if (!context.Request.Cookies.ContainsKey("authenticationToken"))
                {
                    return "Logout successfully";
                }
                else
                {
                    return "Failed to delete token cookie";
                }
            }
            catch (Exception ex)
            {
                // Thêm chi tiết lỗi
                return $"Error occurred while logging out: {ex.Message}";
            }
        }
        #endregion
    }
}
