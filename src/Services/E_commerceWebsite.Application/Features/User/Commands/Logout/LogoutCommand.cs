using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceWebsite.Application.Features.User.Commands.Logout
{
    public class LogoutCommand : IRequest<string>
    {
        public string GuidId { get; set; }

        public LogoutCommand(string guidId)
        {
            GuidId = guidId;
        }
    }
}
