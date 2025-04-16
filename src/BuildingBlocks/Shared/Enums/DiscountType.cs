using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Enums
{
    public enum DiscountType
    {
        [Description("Giảm giá theo phần trăm")]
        Percentage = 1,

        [Description("Giảm giá theo số tiền cố định")]
        FixedAmount = 2,

        [Description("Miễn phí vận chuyển")]
        FreeShipping = 3,

        [Description("Giảm giá khi mua số lượng lớn")]
        BulkDiscount = 4,

        [Description("Giảm giá theo nhóm khách hàng")]
        CustomerGroup = 5,

        [Description("Giảm giá theo sản phẩm cụ thể")]
        ProductSpecific = 6
    }
}
