using E_commerceWebsite.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceWebsite.Application.Features.Role.Commands.CreateRole
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, string>
    {
        private readonly IRolesRepository _rolesRepository;
        public CreateRoleCommandHandler(IRolesRepository rolesRepository) 
        {
            _rolesRepository = rolesRepository;
        }
        public async Task<string> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var roles = await _rolesRepository.CreateAsync(request.Entity);
                return roles;
            }
            catch (Exception ex) 
            {
                return $"Error: {ex.Message}";
            }
        }
    }
}
