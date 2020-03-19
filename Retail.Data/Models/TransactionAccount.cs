using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Retail.Data.Models
{
    public enum TransactionAccount
    {
        [Description("Cash")]
        Cash = 1,
        [Description("Bank")]
        Bank = 2,
        [Description("Credit Card")]
        CreditCard = 3,
        [Description("Debit Card")]
        DebitCard = 4
    }
}
