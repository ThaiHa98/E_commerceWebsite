using Shared.Enums;

namespace E_commerceWebsite.Domain.Entities
{
    public class Order
    {
        public Guid GuidId { get; set; }
        public Guid User_id { get; set; }
        public decimal Total_amount { get; set; }
        public string Full_name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string? Note { get; set; }
        public CartOrderStatus Order_status { get; set; }
        public PaymentStatus Payment_Status { get; set; }
        public PaymentMethod Payment_Method { get; set; }
        public DateTime? Date_Create { get; set; }
        public DateTime? Date_Update { get; set; }
    }
}
