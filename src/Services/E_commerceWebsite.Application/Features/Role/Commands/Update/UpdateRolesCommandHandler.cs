using E_commerceWebsite.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceWebsite.Application.Features.Role.Commands.Update
{
    public class UpdateRolesCommandHandler : IRequestHandler<UpdateRolesCommand, string>
    {
        private readonly IRolesRepository _rolesRepository;
        public UpdateRolesCommandHandler(IRolesRepository rolesRepository) 
        {
            _rolesRepository = rolesRepository;
        }
        public async Task<string> Handle(UpdateRolesCommand request, CancellationToken cancellationToken)
        {
            var entity = await _rolesRepository.UpdateAsync(request.Entity);
            return entity;
        }
    }
}
