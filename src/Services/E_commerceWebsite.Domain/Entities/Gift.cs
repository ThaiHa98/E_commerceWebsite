using Shared.Enums;

namespace E_commerceWebsite.Domain.Entities
{
    public class Gift
    {
        public Guid GuidId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public Guid Product_Id { get; set; }
        public decimal DiscountValue { get; set; }
        public ProductGiftCondition ProductGiftCondition { get; set; }
        public string? Image_url { get; set; }
        public GiftStatus Status { get; set; }
        public DateTime? Start_date { get; set; }
        public DateTime? End_date { get; set; }
    }
}
