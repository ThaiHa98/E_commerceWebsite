using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Enums
{
    public enum VoucherStatus
    {
        [Description("Chưa kích hoạt")]
        Inactive = 0,

        [Description("Đang hoạt động")]
        Active = 1,

        [Description("Hết hạn")]
        Expired = 2,

        [Description("Đã sử dụng")]
        Used = 3,

        [Description("Đã hủy")]
        Canceled = 4
    }
}
