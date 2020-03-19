using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Retail.Data.Models
{
    public enum PaymentType
    {
        [Description("Cash")]
        Cash = 1,
        [Description("Mobile")]
        Mobile = 2,
        [Description("Cheque")]
        Cheque = 3,
        [Description("Bank Transfer")]
        BankTransfer = 4
    }
}
