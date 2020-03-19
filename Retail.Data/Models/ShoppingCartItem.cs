using System;
using System.Collections.Generic;
using System.Text;

namespace Retail.Data.Models
{
    public class ShoppingCartItem
    {
        #region Properties
        public int Id { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        #endregion

        #region Foreign Keys
        public int ProductId { get; set; }
        public int CartId { get; set; }
        #endregion

        #region Virtual Properties
        public virtual ShoppingCart Cart { get; set; }
        public virtual Product Product { get; set; }
        #endregion
    }
}
