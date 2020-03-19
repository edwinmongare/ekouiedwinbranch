using System;
using System.Collections.Generic;
using System.Text;

namespace Retail.Data.Models
{
    public class Payment
    {
        public Payment()
        {
            Receipts = new List<Receipt>();
        }
        public long Id { get; set; }
        public PaymentType PaymentType { get; set; }
        public decimal Amount { get; set; }
        public string TransactionNumber { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactedBy { get; set; }
        #region Foreign Properties
        public int InvoiceId { get; set; }
        public long ReceiptId { get; set; }
        #endregion
        #region Virtuals
        public virtual Invoice Invoice { get; set; }
        public virtual ICollection<Receipt> Receipts { get; set; }
        #endregion
    }
}
