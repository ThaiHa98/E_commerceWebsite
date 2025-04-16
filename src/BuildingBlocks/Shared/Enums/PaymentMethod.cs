using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Enums
{
    public enum PaymentMethod
    {
        [Description("Thanh toán khi nhận hàng")]
        CashOnDelivery = 1,

        [Description("Chuyển khoản ngân hàng")]
        BankTransfer = 2,

        [Description("Thẻ tín dụng/Thẻ ghi nợ")]
        CreditOrDebitCard = 3,

        [Description("Ví điện tử")]
        EWallet = 4,

        [Description("Thanh toán qua cổng trực tuyến")]
        OnlineGateway = 5
    }
}
