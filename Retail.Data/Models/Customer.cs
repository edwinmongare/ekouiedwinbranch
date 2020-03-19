using System;
using System.Collections.Generic;
using System.Text;

namespace Retail.Data.Models
{
    public class Customer
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long BusinessId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string IdNumber { get; set; }
        public string PhysicalAddress { get; set; }
        public string PostalAddress { get; set; }
        public string Website { get; set; }
        public Status Status { get; set; }
        public long BusinessAccountId { get; set; }
        public virtual BusinessAccount BusinessAccount { get; set; }
    }
}
