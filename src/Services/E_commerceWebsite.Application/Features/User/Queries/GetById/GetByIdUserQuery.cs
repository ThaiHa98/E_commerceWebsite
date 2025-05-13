using MediatR;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceWebsite.Application.Features.User.Queries.GetById
{
    public class GetByIdUserQuery : IRequest<UserDto>
    {
        public Guid Id { get; set; }
        public GetByIdUserQuery(Guid id)
        {
            Id = id; 
        }
    }
}
