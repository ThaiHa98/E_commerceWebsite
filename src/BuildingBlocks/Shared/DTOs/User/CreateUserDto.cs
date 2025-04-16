using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public class CreateUserDto
    {
        public string? Last_name { get; set; }
        public string? First_name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Gender { get; set; }
        public string? Phone { get; set; }
        public string? Date_of_birth { get; set; }
        public Guid Role_Id { get; set; }
    }
}
