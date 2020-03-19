using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ekobiashara.Web.Models
{
    public class AddBusinessViewModel
    {
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
        public long CurrencyId { get; set; }
        public long AgentId { get; set; }
        public long PlanId { get; set; }
        public BusinessType BusinessType { get; set; }
    }
}
