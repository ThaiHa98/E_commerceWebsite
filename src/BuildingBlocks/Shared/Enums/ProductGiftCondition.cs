using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Enums
{
    public enum ProductGiftCondition
    {
        [Description("Mua kèm sản phẩm")]
        Bundled = 1,

        [Description("Tặng kèm khi mua hàng trên mức giá nhất định")]
        MinimumPurchase = 2,

        [Description("Tặng theo sự kiện đặc biệt")]
        SpecialEvent = 3
    }
}
