using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Retail.Data.Models
{
    public enum Status
    {
        [Description("Pending")]
        Pending = 0,
        [Description("Active")]
        Active = 1,
        [Description("Disabled")]
        Disabled = 2
    }
}
