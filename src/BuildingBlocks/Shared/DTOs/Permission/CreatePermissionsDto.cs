using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public class CreatePermissionsDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid Role_Id { get; set; }
        public string FunctionCode { get; set; }
    }
}
