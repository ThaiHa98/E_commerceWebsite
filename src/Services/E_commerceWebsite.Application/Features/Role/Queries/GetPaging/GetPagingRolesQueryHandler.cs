using E_commerceWebsite.Application.Common.Interfaces;
using MediatR;
using Shared.DTOs;
using Shared.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceWebsite.Application.Features.Role.Queries.GetPaging
{
    public class GetPagingRolesQueryHandler : IRequestHandler<GetPagingRolesQuery, Pagination<RolesDto>>
    {
        private readonly IRolesRepository _rolesRepository;
        public GetPagingRolesQueryHandler(IRolesRepository rolesRepository) 
        {
            _rolesRepository = rolesRepository;
        }
        public async Task<Pagination<RolesDto>> Handle(GetPagingRolesQuery request, CancellationToken cancellationToken)
        {
            var entity = await _rolesRepository.GetPaging(request.SearchModel);

            return entity;
        }
    }
}
