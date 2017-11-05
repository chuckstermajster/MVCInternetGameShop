using MVCInternetGamesShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MVCInternetGamesShop.ViewModels;
using System.Data.Entity.Infrastructure;

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
        [Authorize(Roles = "CanManageStore")]
        public ActionResult Edit(int id)


        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var game = _context.Games.SingleOrDefault(g => g.Id == id);
            var category = _context.Categories.ToList();
            var categoryId = _context.Categories.Select(c => c.Id).ToList();
            var platformId = _context.Platforms.Select(p => p.Id).ToList();
            var platform = _context.Platforms.ToList();
            var platformName = string.Join(",", _context.Platforms.Where(p => p.Id == game.PlatformId).Select(p => p.Name).ToList());




            GameFormViewModel vm = new GameFormViewModel(game)
            {
                Category = category,
                CategoryId = categoryId,
                PlatformId = platformId,
                Platforms = platform,
                PlatformName = platformName

            };




            if (game == null)
            {
                RedirectToAction("New");
            }

            return View("GameForm", vm);
        }
        [Authorize(Roles = "CanManageStore")]
        public ActionResult New()
        {
            var platforms = _context.Platforms.ToList();
            var category = _context.Categories.ToList();

            var vm = new GameFormViewModel
            {
                Platforms = platforms,
                Category = category

            };
            return View("GameForm", vm);
        }
        [Authorize(Roles = "CanManageStore")]
        public ActionResult Save(Game game)
        {
            if (!ModelState.IsValid)
            {
                var platforms = _context.Platforms.ToList();
                var category = _context.Categories.ToList();

                var vm = new GameFormViewModel
                {
                    Platforms = platforms,
                    Category = category

                };
                return View("GameForm", vm);
            }

            if (game.Id == 0)
            {
                _context.Games.Add(game);
                _context.Entry(game).State = EntityState.Added;
                if (game.ImageName == null)
                {
                    game.ImageName = "DefaultName.jpg";
                }
                _context.SaveChanges();
                return RedirectToAction("Edit", new { Id = game.Id });
            }

            else
            {
                var gameInDb = _context.Games.Single(g => g.Id == game.Id);
                gameInDb.Name = game.Name;
                gameInDb.ImageName = game.ImageName;
                gameInDb.Price = game.Price;
                gameInDb.PlatformId = game.PlatformId;
                gameInDb.IsBestseller = game.IsBestseller;
                gameInDb.ReleaseDate = game.ReleaseDate;
                _context.SaveChanges();
                return View("GameSuccessfullyEdited");
            }



        }



        public ActionResult GetCurrentCategoriesIds(int gameId)
        {
            var CurrentgameId = gameId;
            var currentCategoriesId = _context.GameCategorys.Where(gc => gc.GameID == gameId).Select(gc => gc.CategoryID).ToList();

            return Json(new
            {
                GameId = CurrentgameId,
                CurrentCategoriesId = currentCategoriesId
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult deleteCategoryFromDatabase(GameCategory gameCategory)
        {
            if (!ModelState.IsValid)
            {
                return HttpNotFound();
            }

            else
            {
                var gameCategoriesInDb = _context.GameCategorys;
                _context.Entry(gameCategory).State = EntityState.Deleted;


                gameCategoriesInDb.Remove(gameCategory);
                _context.SaveChanges();
                var currentCategoriesId = _context.GameCategorys.Where(gc => gc.GameID == gameCategory.GameID).Select(gc => gc.CategoryID).ToList();
                return Json(currentCategoriesId);
            }
        }

        public ActionResult AddCategoryToDatabase(GameCategory gameCategory)
        {
            if (!ModelState.IsValid)
            {
                return HttpNotFound();
            }

            else
            {
                var categoriesInDb = _context.GameCategorys;
                categoriesInDb.Add(gameCategory);
                _context.Entry(gameCategory).State = EntityState.Added;
                _context.SaveChanges();
                var currentCategoriesId = _context.GameCategorys.Where(gc => gc.GameID == gameCategory.GameID).Select(gc => gc.CategoryID).ToList();
                return Json(currentCategoriesId);
            }

        }

    }




}
