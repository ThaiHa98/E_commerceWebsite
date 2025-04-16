using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Enums
{
    public enum CartOrderStatus
    {
        [Description("Đơn hàng mới được tạo")]
        New = 1,

        [Description("Đang chờ thanh toán")]
        PendingPayment = 2,

        [Description("Đã thanh toán")]
        Paid = 3,

        [Description("Đang xử lý đơn hàng")]
        Processing = 4,

        [Description("Đang chuẩn bị hàng")]
        Preparing = 5,

        [Description("Đã giao cho đơn vị vận chuyển")]
        Shipped = 6,

        [Description("Đơn hàng đã hoàn tất")]
        Completed = 7,

        [Description("Khách hàng đã hủy đơn")]
        CanceledByCustomer = 8,

        [Description("Hệ thống hủy do lỗi hoặc hết hàng")]
        CanceledBySystem = 9,

        [Description("Khách hàng yêu cầu hoàn hàng")]
        ReturnRequested = 10,

        [Description("Đơn hàng đã được hoàn trả")]
        Returned = 11
    }
}
