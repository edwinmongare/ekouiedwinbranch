using System;
using System.Collections.Generic;
using System.Text;

namespace Retail.Data.Models
{
    public class Currency
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public virtual ICollection<Business> Businesses { get; set; }
    }
}
