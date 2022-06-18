using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Online_Shop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Shop.Models
{
    public class ShoppingCart
    {

        private readonly OnlineShopContext _OnlineShopContext;

        private ShoppingCart(OnlineShopContext onlineShopContext)
        {
            _OnlineShopContext = onlineShopContext;
        }
        public string ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<HttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<OnlineShopContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Products product, int amount)
        {
            var ShoppingCartItem =
                _OnlineShopContext.ShoppingCartItems.SingleOrDefault(
                    s => s.Product.Id == product.Id && s.ShoppingCartId == ShoppingCartId);

            if (ShoppingCartItem == null)
            {
                ShoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Product = product,
                    Amount = 1
                };

                _OnlineShopContext.ShoppingCartItems.Add(ShoppingCartItem);
            }

            else
            {
                ShoppingCartItem.Amount++;

            }
            _OnlineShopContext.SaveChanges();

        }

        public int RemoveFromCart(Products product)
        {
            var ShoppingCartItem =
                _OnlineShopContext.ShoppingCartItems.SingleOrDefault(
                    s => s.Product.Id == product.Id && s.ShoppingCartId == ShoppingCartId);
            var localAmount = 0;
            if (ShoppingCartItem != null)
            {
                if (ShoppingCartItem.Amount > 1)
                {
                    ShoppingCartItem.Amount--;
                    localAmount = ShoppingCartItem.Amount;
                }
                else
                {
                    _OnlineShopContext.ShoppingCartItems.Remove(ShoppingCartItem);
                }

                _OnlineShopContext.SaveChanges();

            }
            return localAmount;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??
                (ShoppingCartItems =
                _OnlineShopContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId).Include(s => s.Product).ToList());

        }

        public void ClearCart()
        {
            var cartItems = _OnlineShopContext.ShoppingCartItems.Where(cart => cart.ShoppingCartId == ShoppingCartId);

            _OnlineShopContext.ShoppingCartItems.RemoveRange(cartItems);

            _OnlineShopContext.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _OnlineShopContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId).
                Select(c => c.Product.Price * c.Amount).Sum();
            return (decimal)total;
        }
    }

}
