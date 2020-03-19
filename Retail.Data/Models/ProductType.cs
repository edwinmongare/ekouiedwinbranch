using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Retail.Data.Models
{
    public enum ProductType
    {
        [Description("Product")]
        Product = 1,
        [Description("Service")]
        Service = 2
    }
}
