using System;
using System.Collections.Generic;
using System.Text;

namespace Retail.Data.Models
{
    public class Expense
    {
        public long Id { get; set; }
        public long BusinessBranchId { get; set; }
        public TransactionAccount TransactionAccount { get; set; }
        public TransactionType TransactionType { get; set; }
        public JournalType JournalType { get; set; }
        public string Notes { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime Transactiondate { get; set; }
    }
}
