using E_commerceWebsite.Application.Common.Interfaces;
using MediatR;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceWebsite.Application.Features.User.Queries.GetById
{
    public class GetByIdUserQueryHandler : IRequestHandler<GetByIdUserQuery, UserDto>
    {
        private readonly IUserRepository _userRepository;
        public GetByIdUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserDto> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetById(request.Id);

            return user;
        }
    }
}
