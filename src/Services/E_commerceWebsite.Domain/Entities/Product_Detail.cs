using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceWebsite.Domain.Entities
{
    public class Product_Detail
    {
        public Guid GuidId { get; set; }
        public Guid Product_id { get; set; }
        public decimal? Weight { get; set; }
        public decimal Product_Warehouse_quantity { get; set; }
        public Guid Product_Warehouse_id { get; set; }
        public string? Image_url { get; set; }
        public DateTime? Date_Create { get; set; }
        public DateTime? Date_Update { get; set; }
    }
}
