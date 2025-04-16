using E_commerceWebsite.Application.Common.Interfaces;
using MediatR;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceWebsite.Application.Features.Role.Queries.GetById
{
    public class GetByIdRolesQueryHandler : IRequestHandler<GetByIdRolesQuery, RolesDto>
    {
        private readonly IRolesRepository _rolesRepository;
        public GetByIdRolesQueryHandler(IRolesRepository rolesRepository) 
        {
            _rolesRepository = rolesRepository;
        }
        public async Task<RolesDto> Handle(GetByIdRolesQuery request, CancellationToken cancellationToken)
        {
            var entity = await _rolesRepository.GetById(request.Id);
            return entity;
        }
    }
}
