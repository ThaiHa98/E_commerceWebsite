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
    public class GetPagingRolesQuery : IRequest<Pagination<RolesDto>>
    { 
        public RolesSearchDto SearchModel { get; private set; }
        public GetPagingRolesQuery(RolesSearchDto searchModel)
        {
            SearchModel = searchModel;
        }
    }
}
