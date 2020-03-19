using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Retail.Data.Models
{
    public enum InventoryType
    {
        [Description("Tracked")]
        Tracked = 1,
        [Description("UnTracked")]
        UnTracked = 2
    }
}
