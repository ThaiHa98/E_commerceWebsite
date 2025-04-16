using Shared.Enums;

namespace E_commerceWebsite.Domain.Entities
{
    public class Invoice
    {
        public Guid GuidId { get; set; }
        public Guid Warehouse_Id { get; set; }
        public InvoiceType Type { get; set; }
        public decimal TotalAmount { get; set; }
        public string? Note { get; set; }
        public string? Image_url { get; set; }
        public DateTime? Date_Create { get; set; }
        public DateTime? Date_Update { get; set; }
    }
}
