using MediatR;
using Shared.DTOs;
using Shared.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceWebsite.Application.Features.Role.Queries.GetById
{
    public class GetByIdRolesQuery : IRequest<RolesDto>
    {
        public string Id { get; private set; }
        public GetByIdRolesQuery(string id)
        {
            Id = id;
        }
    }
}
