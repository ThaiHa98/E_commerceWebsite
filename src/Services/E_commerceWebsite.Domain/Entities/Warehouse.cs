using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceWebsite.Domain.Entities
{
    public class Warehouse
    {
        public Guid GuidId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public WarehouseStatus Status { get; set; }
        public DateTime? Date_Create { get; set; }
        public DateTime? Date_Update { get; set; }
    }
}
