using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceWebsite.Domain.Entities
{
    public class Product_Warehouse
    {
        public Guid GuidId { get; set; }
        public Guid Product_id { get; set; }
        public Guid Warehouse_id { get; set; }
        public decimal Quantity { get; set; }
    }
}
