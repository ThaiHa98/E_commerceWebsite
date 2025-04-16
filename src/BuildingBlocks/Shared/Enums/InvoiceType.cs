using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Enums
{
    public enum InvoiceType
    {
        [Description("Hóa đơn mua hàng")]
        Purchase = 1,

        [Description("Hóa đơn bán hàng")]
        Sale = 2,

        [Description("Hóa đơn trả hàng")]
        Return = 3
    }
}
