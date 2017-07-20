using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCInternetGamesShop.Models;

namespace MVCInternetGamesShop.Controllers
{
    public class CartPossitionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CartPossitions
        public ActionResult Index()
        {
            return View(db.CartPossitions.ToList());
        }

        // GET: CartPossitions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CartPossition cartPossition = db.CartPossitions.Find(id);
            if (cartPossition == null)
            {
                return HttpNotFound();
            }
            return View(cartPossition);
        }

        // GET: CartPossitions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CartPossitions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Quantity,PriceOfItem")] CartPossition cartPossition)
        {
            if (ModelState.IsValid)
            {
                db.CartPossitions.Add(cartPossition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cartPossition);
        }

        // GET: CartPossitions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CartPossition cartPossition = db.CartPossitions.Find(id);
            if (cartPossition == null)
            {
                return HttpNotFound();
            }
            return View(cartPossition);
        }

        // POST: CartPossitions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Quantity,PriceOfItem")] CartPossition cartPossition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cartPossition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cartPossition);
        }

        // GET: CartPossitions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CartPossition cartPossition = db.CartPossitions.Find(id);
            if (cartPossition == null)
            {
                return HttpNotFound();
            }
            return View(cartPossition);
        }

        // POST: CartPossitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CartPossition cartPossition = db.CartPossitions.Find(id);
            db.CartPossitions.Remove(cartPossition);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
