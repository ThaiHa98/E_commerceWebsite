using Shared.Common;

namespace Shared.DTOs
{
    public class RolesSearchDto : SearchPagingModel
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
