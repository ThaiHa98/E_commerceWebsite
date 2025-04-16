using Shared.Enums;

namespace E_commerceWebsite.Domain.Entities
{
    public class User
    {
        public Guid GuidId { get; set; }
        public string? Last_name { get; set; }
        public string? First_name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Gender { get; set; }
        public string? Phone { get; set; }
        public string? Date_of_birth {  get; set; }
        public DateTime? Date_Create {  get; set; }
    }
}
