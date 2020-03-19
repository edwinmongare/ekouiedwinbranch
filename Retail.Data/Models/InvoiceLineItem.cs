using System;
using System.Collections.Generic;
using System.Text;

namespace Retail.Data.Models
{
    public class InvoiceLineItem
    {
        #region Properties
        public long Id { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        #endregion
        #region Foreign Keys
        public long ProductId { get; set; }
        public long InvoiceId { get; set; }
        #endregion
        #region Virtual Properties
        public virtual Invoice Invoice { get; set; }
        #endregion
    }
}
