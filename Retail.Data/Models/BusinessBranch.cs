using System;
using System.Collections.Generic;
using System.Text;

namespace Retail.Data.Models
{
    public class BusinessBranch
    {
        public BusinessBranch()
        {
            Invoices = new List<Invoice>();
        }
        #region Properties
        public long Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string PhysicalAddress { get; set; }
        public string PostalAddress { get; set; }
        public string Email { get; set; }
        #endregion
        #region Foreign Keys
        public long BusinessId { get; set; }
        public virtual Business Business { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        #endregion
    }
}
