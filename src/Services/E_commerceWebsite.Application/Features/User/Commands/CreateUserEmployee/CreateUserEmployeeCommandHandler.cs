using E_commerceWebsite.Application.Common.Interfaces;
using MediatR;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceWebsite.Application.Features.User.Commands.CreateUserEmployee
{
    public class CreateUserEmployeeCommandHandler : IRequestHandler<CreateUserEmployeeCommand, string>
    {
        private readonly IUserRepository _userRepository;
        public CreateUserEmployeeCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<string> Handle(CreateUserEmployeeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userRepository.InsertAsyncEmployee(request.Entity);
                return user;
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
    }
}
