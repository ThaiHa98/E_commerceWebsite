using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceWebsite.Domain.Entities
{
    public class Voucher
    {
        public Guid GuidId { get; set; }
        public string Code { get; set; }
        public string? Description { get; set; }
        public DiscountType Discount_type { get; set; }
        public decimal Discount_value { get; set; }
        public decimal Min_purchase_amount { get; set; }
        public VoucherStatus Status { get; set; }
        public DateTime? Start_date { get; set; }
        public DateTime? End_date { get;set; }


    }
}
