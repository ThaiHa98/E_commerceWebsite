using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public class KeyAppDto
    {
        public string ServiceKeyId { get; set; }  // VD: MyService.Production
        public string NameKey { get; set; }       // VD: ClientId
        public string Value { get; set; }         // VD: 123456789
        public string? Description { get; set; }
    }
}
