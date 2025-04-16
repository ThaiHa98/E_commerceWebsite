using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Enums
{
    public enum GiftStatus
    {
        [Description("Đang hoạt động")]
        Active = 1,

        [Description("Hết hạn")]
        Expired = 2,

        [Description("Đã hủy")]
        Canceled = 3
    }
}
