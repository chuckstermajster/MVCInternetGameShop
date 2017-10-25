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
            var categoryId = _context.Categories.Select(c => c.Id).ToList();
            var platformId = _context.Platforms.Select(p => p.Id).ToList();
            var platform = _context.Platforms.ToList();
            var currentCategoriesId = _context.GameCategorys.Where(gc => gc.GameID == id).Select(gc => gc.CategoryID).ToList();
            var currentCategories = category.Where(t => currentCategoriesId.Contains(t.Id)).ToList();
            var remainsCategories = category.Except(currentCategories).ToList();
            var currentCategoriesNames = string.Join(",", currentCategories.Select(c => c.Name).ToList());


            GameFormViewModel vm = new GameFormViewModel(game)
            {
                Category = category,
                CategoryId = categoryId,
                PlatformId = platformId,
                Platforms = platform,
                CurrentCategories = currentCategories,
                RemainsCategories = remainsCategories,
                CurrentCategoriesNames = currentCategoriesNames

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
            var category = _context.Categories.ToList();

            var vm = new GameFormViewModel
            {
                Platforms = platforms,
                Category = category
                
            };
            return View("GameForm", vm);
        }

        public ActionResult Save(Game game, List<int> selectedIds)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("New", "Games");
            }

            if (game.Id == 0)
            {
                _context.Games.Add(game);
            }

            else

            
            {

               
                    var gameInDb = _context.Games.Single(g => g.Id == game.Id);

                var gameCategoriesToAdd = new List<GameCategory>();

                foreach (var chosenCategoryId in selectedIds)
                {
                    var gameCategory = new GameCategory
                    {
                        GameID = gameInDb.Id,
                        CategoryID = chosenCategoryId

                    };
                    _context.GameCategorys.Add(gameCategory);
                }




                
            }

            _context.SaveChanges();
            return View();
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
