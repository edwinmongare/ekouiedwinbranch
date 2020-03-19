using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ekobiashara.Web.Downloaders
{
    public class BusinessDownloadSerializer
    {
        public long Id { get; set; }
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
        public string Agent { get; set; }
        public decimal Expenses { get; set; }
        public decimal Income { get; set; }
        public decimal Profit { get; set; }
    }
}
