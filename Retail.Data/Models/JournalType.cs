using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Retail.Data.Models
{
    public enum JournalType
    {
        [Description("Debit")]
        Debit = 1,
        [Description("Credit")]
        Credit = 2
    }
}
