using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceWebsite.Domain.Entities
{
    public class Order_Detail
    {
        public Guid GuidId { get; set; }
        public Guid Order_id { get; set; }
        public Guid Product_id { get; set; }
        public string Product_name { get; set; }
        public decimal Unit_price { get; set; }
        public decimal Total_price { get; set; }
        public string? Image_url { get; set; }
        public decimal Quantity { get; set; }
    }
}
