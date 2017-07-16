using MVCInternetGamesShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace MVCInternetGamesShop.Controllers
{
    public class GamesController : Controller
    {
        private ApplicationDbContext _context;

        public GamesController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Details(int id)
        {
            var games = _context.Games.Include(g => g.Platform).SingleOrDefault(g => g.Id == id);
            if (games == null)
                return HttpNotFound();
            return View(games);
        }
    }
}