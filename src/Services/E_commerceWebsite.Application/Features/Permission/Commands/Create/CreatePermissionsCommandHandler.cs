using E_commerceWebsite.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceWebsite.Application.Features.Permission.Commands.Create
{
    public class CreatePermissionsCommandHandler : IRequestHandler<CreatePermissionsCommand, string>
    {
        private readonly IPermissionsRepository _permissionsRepository;
        public CreatePermissionsCommandHandler(IPermissionsRepository permissionsRepository) 
        {
            _permissionsRepository = permissionsRepository;
        }
        public async Task<string> Handle(CreatePermissionsCommand request, CancellationToken cancellationToken)
        {
            var entity = await _permissionsRepository.CreateAsync(request.Entity);
            return entity;
        }
    }
}
