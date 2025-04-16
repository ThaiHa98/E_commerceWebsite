using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Enums
{
    public enum WarehouseStatus
    {
        [Description("Kho đang mở và hoạt động")]
        Open = 1,

        [Description("Kho đang đóng cửa")]
        Closed = 2,

        [Description("Kho đang bảo trì")]
        UnderMaintenance = 3,

        [Description("Kho đang chuyển đổi hoặc di dời")]
        Relocating = 4
    }
}
