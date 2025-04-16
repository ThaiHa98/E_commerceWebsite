using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Enums
{
    public enum PaymentStatus
    {
        [Description("Chưa thanh toán")]
        Unpaid = 1,

        [Description("Đã thanh toán")]
        Paid = 2,

        [Description("Đang xử lý")]
        Processing = 3,

        [Description("Hoàn tiền")]
        Refunded = 4,

        [Description("Thanh toán thất bại")]
        Failed = 5
    }
}
