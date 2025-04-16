using E_commerceWebsite.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceWebsite.Application.Features.User.Commands.Logout
{
    public class LogoutCommandHandler : IRequestHandler<LogoutCommand, string>
    {
        private readonly IUserRepository _userRepository;
        public LogoutCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<string> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var guid = Guid.Parse(request.GuidId);
                var user = await _userRepository.Logout(guid);
                return user;
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
    }
}
