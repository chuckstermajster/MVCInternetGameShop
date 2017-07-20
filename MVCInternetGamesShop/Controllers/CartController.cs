using MVCInternetGamesShop.Infrastructure;
using MVCInternetGamesShop.Models;
using MVCInternetGamesShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCInternetGamesShop.Controllers
{
    public class CartController : Controller
    {
        private CartManager cartManager;
        private ISessionManager sessionManager;

        private ApplicationDbContext _context;

        public CartController()
        {
            _context = new ApplicationDbContext();
            sessionManager = new SessionManager();
            cartManager = new CartManager(sessionManager, _context);
        }


        public ActionResult Index()
        {
            var cartPosition = cartManager.GetCart();
            var totalPrice = cartManager.GetValueOfCart();
            CartViewModel viewModel = new CartViewModel
            {
                CartPosition = cartPosition,
                TotalPrice = totalPrice

            };

            return View(viewModel);
        }

        public ActionResult AddToCart(int id)
        {
            cartManager.AddToCart(id);
            return RedirectToAction("Index");
        }
    }
}