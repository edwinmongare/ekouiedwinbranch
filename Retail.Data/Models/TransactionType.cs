using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Retail.Data.Models
{
    public enum TransactionType
    {
        [Description("Expense")]
        Expense = 1,
        [Description("Purchase")]
        Purchase = 2,
        [Description("Sale")]
        Sale = 3,
        [Description("Internal Transaction")]
        InternalTransaction = 4,
        [Description("DirectExpense")]
        DirectExpense = 5,
        [Description("Cost Of Sales")]
        CostOfSales = 6
    }
}
