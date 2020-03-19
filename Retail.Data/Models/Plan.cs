using System;
using System.Collections.Generic;
using System.Text;

namespace Retail.Data.Models
{
    public class Plan
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<Business> Businesses { get; set; }
    }
}
