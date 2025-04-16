using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceWebsite.Domain.Entities
{
    public class Product
    {
        public Guid GuidId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public Guid Category_id { get; set; }
        public Guid Brand_id { get; set; }
        public string? Colors { get; set; }
        public string? Image_url { get; set; }
        public ProductStatus Status { get; set; }
        public DateTime? Date_Create { get; set; }
        public DateTime? Date_Update { get; set; }
    }
}
