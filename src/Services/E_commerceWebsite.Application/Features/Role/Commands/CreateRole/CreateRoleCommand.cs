using MediatR;
using Shared.DTOs;

namespace E_commerceWebsite.Application.Features.Role.Commands.CreateRole
{
    public class CreateRoleCommand : IRequest<string>
    {
        public CreateRolesDto Entity { get; set; }

        public CreateRoleCommand(CreateRolesDto entity) 
        {
            Entity = entity;
        }
    }
}
