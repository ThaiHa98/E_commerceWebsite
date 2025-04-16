using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceWebsite.Domain.Entities
{
    public class Product_Price_Discount
    {
        public Guid GuidId { get; set; }
        public Guid Product_id { get; set; }
        public decimal Price { get; set; }
        public decimal? Discount_percentage { get; set; }
        public decimal? Discount_amount { get; set; }
        public string Type { get; set; }
        public DateTime? Start_date { get; set; }
        public DateTime? End_date { get;set; }
        public DateTime? Date_Create { get; set; }
        public DateTime? Date_Update { get; set; }
    }
}
