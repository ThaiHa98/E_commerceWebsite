using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceWebsite.Domain.Entities
{
    public class KeyApp
    {
        public Guid Id { get; set; }
        public string ServiceKeyId { get; set; }    // VD: "MyApp.Production"
        public string NameKey { get; set; }         // VD: "ClientId", "ClientSecret"
        public string Value { get; set; }           // VD: actual value
        public string? Description { get; set; }    // Mô tả ý nghĩa cấu hình
        public DateTime CreatedDate { get; set; }
    }
}
