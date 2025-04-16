using E_commerceWebsite.Domain.Entities;
using E_commerceWebsite.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace E_commerceWebsite.Infrastructure.Helper
{
    public class Token
    {
        private readonly E_commerceWebsiteDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public Token(E_commerceWebsiteDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }
        //Create token
        public string CreateToken(User user)
        {
            // 1. Lấy danh sách RoleId của User
            var roleIds = _dbContext.UsersRoles
                .Where(ur => ur.User_Id == user.GuidId)
                .Select(ur => ur.Role_Id)
                .ToList();

            // 2. Lấy danh sách Role_Name (Admin, AdminCreate, ...)
            var roleNames = _dbContext.UsersRoles
                .Where(ur => ur.User_Id == user.GuidId)
                .Select(ur => ur.Role_Name)
                .Distinct()
                .ToList();

            // 3. Lấy danh sách Permission dạng "FunctionCode_CommandCode"
            var permissionList = _dbContext.RolePermissions
                .Where(rp => roleIds.Contains(rp.Role_Id))
                .Select(rp => rp.FunctionCode + "_" + rp.CommandCode)
                .Distinct()
                .ToList();

            // 4. Tạo claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.GuidId.ToString()),
                new Claim(ClaimTypes.GivenName, user.First_name ?? ""),
                new Claim(ClaimTypes.Surname, user.Last_name ?? ""),
                new Claim(ClaimTypes.Email, user.Email ?? ""),
                new Claim("roles", string.Join(";", roleNames))
            };

            // 5. Thêm từng permission vào claims
            foreach (var permission in permissionList)
            {
                claims.Add(new Claim("permissions", permission));
            }

            // 6. Tạo token
            var key = new SymmetricSecurityKey(Convert.FromBase64String(_configuration.GetSection("Jwt:Token256").Value));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            DateTime now = DateTime.Now;
            DateTime expiration = now.AddMinutes(60);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: expiration,
                signingCredentials: cred,
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"]
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        // Phương thức xác thực token
        public bool ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Token256"]));
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidIssuer = _configuration["Jwt:Issuer"],
                ValidAudience = _configuration["Jwt:Audience"],
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = key,
            };
            try
            {
                // ValidateToken ném ra ngoại lệ nếu mã thông báo không hợp lệ
                SecurityToken validatedToken;
                var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out validatedToken);

                // Nếu không có lỗi ném ra, token hợp lệ
                return true;
            }
            catch (Exception ex)
            {
                // Xử lý lỗi xác thực token
                return false;
            }
        }

        // Phương thức lấy ClaimsPrincipal từ token
        public ClaimsPrincipal GetPrincipalFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Token256"]));
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidIssuer = _configuration["Jwt:Issuer"],
                ValidAudience = _configuration["Jwt:Audience"],
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = key,
            };
            try
            {
                var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var validatedToken);
                return principal;
            }
            catch (Exception ex)
            {
                throw new Exception("Error when validating token", ex);
            }
        }
    }
}
