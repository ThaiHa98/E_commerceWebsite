using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceWebsite.Domain.Entities
{
    public class Department
    {
        public Guid GuidId { get; set; }
        public Guid User_Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
