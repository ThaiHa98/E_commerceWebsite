using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Enums
{
    public enum ProductStatus
    {
        [Description("Chưa kích hoạt")]
        Inactive = 0,

        [Description("Đang hoạt động")]
        Active = 1,

        [Description("Hết hàng")]
        OutOfStock = 2,

        [Description("Ngừng kinh doanh")]
        Discontinued = 3
    }
}
