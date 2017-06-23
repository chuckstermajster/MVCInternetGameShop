using MVCInternetGamesShop.Models;
using MVCInternetGamesShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCInternetGamesShop.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var xboxBestsellers = _context.Games.Where(a => a.IsBestseller == true && a.PlatformId == 3).OrderBy(a => Guid.NewGuid()).Take(3).ToList();
            var xboxNewest = _context.Games.Where(a => a.PlatformId == 3).OrderByDescending(a => a.ReleaseDate).Take(3).ToList();
            var ps4Bestsellers = _context.Games.Where(a => a.IsBestseller == true && a.PlatformId == 1).OrderBy(a => Guid.NewGuid()).Take(3).ToList();
            var ps4Newest = _context.Games.Where(a => a.PlatformId == 1).OrderByDescending(a => a.ReleaseDate).Take(3).ToList();
            var PCBestsellers = _context.Games.Where(a => a.IsBestseller == true && a.PlatformId == 2).OrderBy(a => Guid.NewGuid()).Take(3).ToList();
            var PCNewest = _context.Games.Where(a => a.PlatformId == 2).OrderByDescending(a => a.ReleaseDate).Take(3).ToList();

            var viewModel = new HomeViewModel()
            {
                XBoxBestsellers = xboxBestsellers,
                XBoxNewest = xboxNewest,
                PCBestsellers = PCBestsellers,
                PCNewest = PCNewest,
                Ps4Bestsellers = ps4Bestsellers,
                Ps4Newest = ps4Newest

            };
            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}