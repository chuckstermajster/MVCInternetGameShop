using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using MVCInternetGamesShop.Infrastructure;
using MVCInternetGamesShop.Models;
using MVCInternetGamesShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVCInternetGamesShop.Controllers
{
    public class CartController : Controller
    {
        private CartManager cartManager;
        private ISessionManager sessionManager;
        private ApplicationDbContext _context;        
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

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

        public int AddToCart(int id)
        {
            cartManager.AddToCart(id);
            return GetHowManyItemsInCart();
        }

        public int GetHowManyItemsInCart()
        {
            int itemsInCart = cartManager.GetQuantityOfCartPossitions();
            return itemsInCart;
        }

        public ActionResult DeleteFromCart(int id)
        {
            var currentPositionQuantity = cartManager.RemoveFromCart(id);
            var currentTotalPrice = cartManager.GetValueOfCart();
            var currentItemsInCartQuantity = GetHowManyItemsInCart();
            var vm = new DeleteFromCartViewModel
            {
                CurrentPositionId = id,
                CurrentPostionQuantity = currentPositionQuantity,
                TotalPrice = currentTotalPrice,
                CurrentItemsInCartQuantity = currentItemsInCartQuantity

            };
            return Json(vm);
        }

        public async Task<ActionResult> Pay()
        {
            if (Request.IsAuthenticated)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                var order = new Order
                {
                    Name = user.Name,
                    Street = user.Street,
                    
                 
                };
             

                return View(order);
            }

            else
            {
                return RedirectToAction("Login", "Account",  new { returnUrl = Url.Action("Pay", "Cart") });
            }
        }

        public async Task<ActionResult> Confirm(Order order)
        {
            if (ModelState.IsValid)
            {
                
                var userId = User.Identity.GetUserId();

                
                var newOrder = cartManager.CreateOrder(order, userId);

                
                var user = await UserManager.FindByIdAsync(userId);
                user.City = order.City;
                user.Street = order.Street;
                user.StreetNumber = order.StreetNumber;
                user.HouseNumber = order.HouseNumber;
                user.PostCode = order.PostCode;
                user.Name = order.Name;
               await _context.SaveChangesAsync();


                
                cartManager.EmptyCart();

               

                return RedirectToAction("OrderConfirmation");
            }
            else
                return View(order);
        }

        public ActionResult OrderConfirmation()
        {

            return View();
        }


    }
}