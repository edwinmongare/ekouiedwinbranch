using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Retail.Data.Models
{
    public enum InvoiceStage
    {
        [Description("Quotation")]
        Quotation = 1,
        [Description("Invoice")]
        Invoice = 2,
        [Description("Delivery")]
        Delivery = 3
    }
}
