using Retail.Data.Database;
using Retail.Data.Models;
using Retail.Data.Repositories.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Retail.Data.Repositories
{
    public class ShoppingCartRepository : Repository<ShoppingCart>
    {
        private EkoDataContext _ekoDataContext;

        public ShoppingCartRepository(EkoDataContext context) : base(context)
        {
            _ekoDataContext = context as EkoDataContext;
        }
        public List<ShoppingCartItem> GetShoppingCartItems(int cartId)
        {
            var cartItems = _ekoDataContext.ShoppingCartItems.Where(p => p.CartId.Equals(cartId)).ToList();
            return cartItems;
        }
        public decimal GetShoppingTotalCost(int cartId)
        {

            var totalCost = _ekoDataContext.ShoppingCartItems
                                              .Where(p => p.CartId.Equals(cartId))
                                              .Sum(p => p.Quantity * p.UnitPrice);
            return totalCost;
        }
        public decimal GetShoppingCartItemsCount(int cartId)
        {
            var count = _ekoDataContext.ShoppingCartItems
                                                .Where(p => p.CartId.Equals(cartId))
                                                .Sum(p => p.Quantity);
            return count;
        }
    }
}
