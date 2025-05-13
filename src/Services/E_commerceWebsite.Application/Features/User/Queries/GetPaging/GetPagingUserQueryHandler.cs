using E_commerceWebsite.Application.Common.Interfaces;
using MediatR;
using Shared.DTOs;
using Shared.SeedWork;

namespace E_commerceWebsite.Application.Features.User.Queries.GetPaging
{
    public class GetPagingUserQueryHandler : IRequestHandler<GetPagingUserQuery, Pagination<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        public GetPagingUserQueryHandler(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }
        public async Task<Pagination<UserDto>> Handle(GetPagingUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetPaging(request.SearchModel);

            return user;
        }
    }
}
