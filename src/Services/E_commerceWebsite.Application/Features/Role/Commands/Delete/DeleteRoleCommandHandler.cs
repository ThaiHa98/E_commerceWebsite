using E_commerceWebsite.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceWebsite.Application.Features.Role.Commands.Delete
{
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand, string>
    {
        private readonly IRolesRepository _rolesRepository;
        public DeleteRoleCommandHandler(IRolesRepository rolesRepository) 
        {
            _rolesRepository = rolesRepository;
        }
        public async Task<string> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var roles = await _rolesRepository.DeletesAsync(request.Guidid);
            return roles;
        }
    }
}
