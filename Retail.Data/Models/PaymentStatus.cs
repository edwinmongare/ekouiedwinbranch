using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Retail.Data.Models
{
    public enum PaymentStatus
    {
        [Description("Pending")]
        Pending = 0,
        [Description("Ongoing")]
        Ongoing = 1,
        [Description("Completed")]
        Completed = 2
    }
}
