using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ekobiashara.Web.Downloaders
{
    public class CustomerStatement
    {
        public DateTime TransactionTime { get; set; }

        public string TransactionType { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public decimal Balance { get; set; }
    }
}
