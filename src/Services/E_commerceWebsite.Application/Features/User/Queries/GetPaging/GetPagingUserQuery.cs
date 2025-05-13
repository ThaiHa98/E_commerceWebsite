using MediatR;
using Shared.DTOs;
using Shared.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceWebsite.Application.Features.User.Queries.GetPaging
{
    public class GetPagingUserQuery : IRequest<Pagination<UserDto>>
    {
        public UserSearchDto SearchModel { get; set; }

        public GetPagingUserQuery(UserSearchDto searchModel) 
        {
            SearchModel = searchModel;
        }

    }
}
