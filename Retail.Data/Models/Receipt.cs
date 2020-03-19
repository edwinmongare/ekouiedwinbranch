using System;
using System.Collections.Generic;
using System.Text;

namespace Retail.Data.Models
{
    public class Receipt
    {
        #region Properties
        public long Id { get; set; }
        public string ReceiptNumber { get; set; }
        public decimal InvoiceAmount { get; set; }
        public decimal Paid { get; set; }
        public decimal Balance { get; set; }
        #endregion
        #region Foreign Keys
        public long PaymentId { get; set; }
        #endregion
        #region Virtuals
        public virtual Payment Payment { get; set; }
        #endregion
    }
}
