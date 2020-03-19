using System;
using System.Collections.Generic;
using System.Text;

namespace Retail.Data.Models
{
    public class Business
    {
        public Business()
        {
            Products = new List<Product>();
            BusinessBranches = new List<BusinessBranch>();
        }
        #region Properties
        public long Id { get; set; }
        public string IdentityId { get; set; }
        public string Name { get; set; }
        public string PINNumber { get; set; }
        public string Logo { get; set; }
        public string Slogan { get; set; }
        public string ReceiptFootNote { get; set; }
        public string InvoiceFootNote { get; set; }
        public string QuotationFootNote { get; set; }
        public string PhysicalAddress { get; set; }
        public string PostalAddress { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Social { get; set; }
        public Status Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public BusinessType BusinessType { get; set; }
        #endregion
        #region Foreign Keys
        public long CurrencyId { get; set; }
        public long AgentId { get; set; }
        public long PlanId { get; set; }
        #endregion
        #region Virtuals
        public virtual Currency Currency { get; set; }
        public virtual Agent Agent { get; set; }
        public virtual Plan Plan { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<BusinessBranch> BusinessBranches { get; set; }
        #endregion
    }
}
