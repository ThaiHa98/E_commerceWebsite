using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceWebsite.Domain.Entities
{
    public class Category
    {
        public Guid GuidId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Product_Type { get; set; }
        public DateTime? Date_Create { get; set; }
    }
}
