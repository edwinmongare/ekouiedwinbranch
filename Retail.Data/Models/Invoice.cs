using System;
using System.Collections.Generic;
using System.Text;

namespace Retail.Data.Models
{
    public class Invoice
    {
        public Invoice()
        {
            InvoiceLineItems = new List<InvoiceLineItem>();
            Transactions = new List<Transaction>();
        }
        #region Properties
        public long Id { get; set; }
        public string InvoiceNumber { get; set; }
        public decimal Amount { get; set; }
        public InvoiceStage InvoiceStage { get; set; }
        public InvoiceStatus InvoiceStatus { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime LastUpdateDateTime { get; set; }
        #endregion
        #region Foreign Keys
        public long PaymentId { get; set; }
        public long BusinessAccountId { get; set; }
        public long BusinessBranchId { get; set; }
        #endregion
        #region Virtuals
        public virtual Payment Payment { get; set; }
        public virtual BusinessAccount BusinessAccount { get; set; }
        public virtual ICollection<InvoiceLineItem> InvoiceLineItems { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        #endregion
    }
}
