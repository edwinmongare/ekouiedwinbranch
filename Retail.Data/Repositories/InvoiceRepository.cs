using Microsoft.EntityFrameworkCore;
using Retail.Data.Database;
using Retail.Data.Helpers;
using Retail.Data.Models;
using Retail.Data.Repositories.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Retail.Data.Repositories
{
    public class InvoiceRepository : Repository<Invoice>
    {
        private EkoDataContext _ekoDataContext;

        public InvoiceRepository(EkoDataContext context) : base(context)
        {
            _ekoDataContext = context as EkoDataContext;
        }
        public string GetNextInvoiceNumber(string prefix = "EB")
        {
            var orderNumber = string.Empty;
            do
            {
                orderNumber = RandomNumberGenerator.GetCustomerNumber(prefix);
            } while ((Find(p => p.InvoiceNumber.Equals(orderNumber)).FirstOrDefault() != null));
            return orderNumber;
        }

        public List<Product> GetLineItems(long orderId)
        {

            var lineItems = _ekoDataContext.InvoiceLineItems.Where(p => p.InvoiceId.Equals(orderId)).Select(x => x.ProductId);
            var products = _ekoDataContext.Products.Where(p => lineItems.Contains(p.Id)).ToList(); ;
            return products;
        }
        public long GetShoppingLineItemsCount(long orderId)
        {

            var count = _ekoDataContext.InvoiceLineItems
                                                .Where(p => p.InvoiceId.Equals(orderId))
                                                .Sum(p => p.Quantity);
            return count;
        }
        public decimal GetOrderTotalCost(long orderId)
        {
            var totalCost = _ekoDataContext.InvoiceLineItems
                                             .Where(p => p.InvoiceId.Equals(orderId))
                                             .Sum(p => p.Quantity * p.UnitPrice);

            return totalCost;
        }
      
    }
}