using System;
using System.Collections.Generic;
using System.Text;

namespace Retail.Data.Models
{
    public class Inventory
    {
        #region Properties
        public long Id { get; set; }
        public long Quantity { get; set; }
        public decimal Value { get; set; }
        #endregion
    }
}
