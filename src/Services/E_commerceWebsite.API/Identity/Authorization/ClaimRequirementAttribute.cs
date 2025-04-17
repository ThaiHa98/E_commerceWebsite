using Microsoft.AspNetCore.Mvc;
using Shared.Enums;
using Warehouse.API.Identity.Authorization;

namespace E_commerceWebsite.API.Identity.Authorization
{
    public class ClaimRequirementAttribute : TypeFilterAttribute
    {
        public ClaimRequirementAttribute(FunctionCode functionId, CommandCode commandId)
            : base(typeof(ClaimRequirementFilter))
        {
            Arguments = new object[] { functionId, commandId };
        }
    }
}
