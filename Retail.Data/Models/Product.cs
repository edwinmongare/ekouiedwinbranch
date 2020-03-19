using System;
using System.Collections.Generic;
using System.Text;

namespace Retail.Data.Models
{
    public class Product
    {
        #region Properties
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal BuyingPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public ProductType ProductType { get; set; }
        public InventoryType InventoryType { get; set; }
        public Status Status { get; set; }
        public string SupplierId { get; set; }
        #endregion
        #region Foreign Keys
        public long BusinessId { get; set; }
        public long TaxId { get; set; }
        public long InventoryId { get; set; }
        #endregion
        #region Virtuals
        public virtual Business Business { get; set; }
        public virtual Inventory Inventory { get; set; }
        #endregion
    }
}
