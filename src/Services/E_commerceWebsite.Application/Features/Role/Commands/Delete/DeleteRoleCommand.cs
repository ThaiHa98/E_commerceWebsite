using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceWebsite.Application.Features.Role.Commands.Delete
{
    public class DeleteRoleCommand : IRequest<string>
    {
        public Guid Guidid { get; set; }
        public DeleteRoleCommand(Guid guidid)
        {
            Guidid = guidid;
        }
    }
}
