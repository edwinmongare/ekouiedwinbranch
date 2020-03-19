using System;
using System.Collections.Generic;
using System.Text;

namespace Retail.Data.Models
{
    public class Transaction
    {
        #region Properties
        public long Id { get; set; }
        public TransactionAccount TransactionAccount { get; set; }
        public TransactionType TransactionType { get; set; }
        public JournalType JournalType { get; set; }
        #endregion
        #region Foreign Keys
        public long InvoiceId { get; set; }
        #endregion
        #region Virtual Properties
        public virtual Invoice Invoice { get; set; }
        #endregion
    }
}
