using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceWebsite.Domain.Entities
{
    public class WarehouseInvoiceDetail
    {
        public Guid GuidId { get; set; }
        public Guid Invoice_Id { get; set; }
        public Guid Product_Id { get; set; }
        public Guid Warehouse_Id { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime? Date_Create { get; set; }
        public DateTime? Date_Update { get; set; }
    }
}
