using MVCInternetGamesShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MVCInternetGamesShop.ViewModels;

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

        public ActionResult Edit(int id)
        {
            var game = _context.Games.SingleOrDefault(g => g.Id == id);
            var category = _context.Categories.ToList();
            var categoryId = _context.Categories.Select(x => x.Id).ToList();
            var platformId = _context.Platforms.Select(x => x.Id).ToList();
            var platform = _context.Platforms.ToList();

            GameFormViewModel vm = new GameFormViewModel(game)
            {
                Category = category,
                CategoryId = categoryId,
                PlatformId = platformId,
                Platforms = platform              
                

            };




            if (game == null)
            {
                RedirectToAction("New");
            }

            return View("GameForm", vm);
        }

        public ActionResult New()
        {
            var platforms = _context.Platforms.ToList();

            var vm = new GameFormViewModel
            {
                Platforms = platforms
            };
            return View("GameForm", vm);
        }

        public ActionResult Save(Game game, byte categoryId)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("New", "Games");
            }

            else
            {
                var gameInDb = _context.Games.Single(g => g.Id == game.Id);
                
                var gameCategories = new GameCategory
                {
                    CategoryID = categoryId,
                    GameID = gameInDb.Id
                };
                _context.GameCategorys.Add(gameCategories);
                gameInDb.Name = game.Name;

                
                _context.SaveChanges();
            }
            return View();
        }


    }
}