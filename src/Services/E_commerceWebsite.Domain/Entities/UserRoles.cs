using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceWebsite.Domain.Entities
{
    public class UserRoles
    {
        public Guid GuidId { get; set; }
        public Guid User_Id { get; set; }
        public string User_Name { get; set; }
        public Guid Role_Id { get; set; }
        public string Role_Name { get; set; }

    }
}
