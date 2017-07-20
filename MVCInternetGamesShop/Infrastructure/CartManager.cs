using MVCInternetGamesShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCInternetGamesShop.Infrastructure
{
    public class CartManager
    {

        private ApplicationDbContext _context;
        private ISessionManager session;
        public CartManager(ISessionManager session, ApplicationDbContext _context)
        {
            this.session = session;
            this._context = _context;
        }

        public List<CartPosition> GetCart()
        {
            List<CartPosition> cart;

            if (session.Get<List<CartPosition>>(Const.CartSessionKey) == null)
            {
                cart = new List<CartPosition>();
            }

            else
            {
                cart = session.Get<List<CartPosition>>(Const.CartSessionKey) as List<CartPosition>;
            }

            return cart;
        }

        public void AddToCart(int gameId)
        {
            var cart = GetCart();
            var cartPossition = cart.Find(c => c.Game.Id == gameId);

            if(cartPossition != null)
            {
                cartPossition.Quantity++;
            }

            else
            {
                var gameToAdd = _context.Games.Where(k => k.Id == gameId).SingleOrDefault();

                if (gameToAdd != null)
                {
                    var newCartPossition = new CartPosition()
                    {
                        Game = gameToAdd,
                        PriceOfItem = gameToAdd.Price,
                        Quantity = 1
                    };
                    cart.Add(newCartPossition);
                }                
            }
            session.Set(Const.CartSessionKey, cart);
        }

        public int RemoveFromCart(int gameId)
        {
            var cart = GetCart();
            var cartPossition = cart.Find(k => k.Game.Id == gameId);

            if(cartPossition != null)
            {
                if(cartPossition.Quantity > 1)
                {
                    cartPossition.Quantity--;
                }

                else
                {
                    cart.Remove(cartPossition);
                }
            }
            return 0;
        }

        public decimal GetValueOfCart()
        {
            var cart = GetCart();
            return cart.Sum(k => (k.Quantity * k.PriceOfItem));
        }

        public int GetQuantityOfCartPossitions()
        {
            var cart = GetCart();
            int quantity = cart.Sum(k => k.Quantity);
            return quantity;
        }

        public Order CreateOrder(Order order, string userId)
        {
            var cart = GetCart();
            order.CreationTime = DateTime.Now;
            //order.UserId = userId;
            _context.Orders.Add(order);
            //POZYCJE ZAMOWiENIA
            return order;
        }

        public void EmptyCart()
        {
            session.Set<List<CartPosition>>(Const.CartSessionKey, null);
        }
    }
}