using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pelikan_strona.Models;

namespace Pelikan_strona.Controllers
{
    [Authorize(Roles = "Klient")]
    public class DodajKrewnegoController : Controller
    {
        private UsersContext db = new UsersContext();

        //
        // GET: /DodajKrewnego/

        public ActionResult Index()

        {
            var user = db.UserProfiles.Single(u => u.UserName == User.Identity.Name).UserId;
            var członekr = db.CzłonekR.Include(c => c.UserProfile).Where(u => u.UserId == user);
            return View(członekr.ToList());
        }

        //
        // GET: /DodajKrewnego/Details/5

        public ActionResult Details(int id = 0)
        {
            CzlonekRodziny czlonekrodziny = db.CzłonekR.Find(id);
            if (czlonekrodziny == null)
            {
                return HttpNotFound();
            }
            return View(czlonekrodziny);
        }

        //
        // GET: /DodajKrewnego/Create

        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName");
            return View();
        }

        //
        // POST: /DodajKrewnego/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CzlonekRodziny czlonekrodziny)
        {
            if (ModelState.IsValid)
            {
                czlonekrodziny.UserId = db.UserProfiles.Single(u => u.UserName == User.Identity.Name).UserId;
                czlonekrodziny.User_Pesel = db.UserProfiles.Single(u => u.UserName == User.Identity.Name).User_Pesel;
                db.CzłonekR.Add(czlonekrodziny);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", czlonekrodziny.UserId);
            return View(czlonekrodziny);
        }

        //
        // GET: /DodajKrewnego/Edit/5

        public ActionResult Edit(int id = 0)
        {
            CzlonekRodziny czlonekrodziny = db.CzłonekR.Find(id);
            if (czlonekrodziny == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", czlonekrodziny.UserId);
            return View(czlonekrodziny);
        }

        //
        // POST: /DodajKrewnego/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CzlonekRodziny czlonekrodziny)
        {
            if (ModelState.IsValid)
            {
                db.Entry(czlonekrodziny).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", czlonekrodziny.UserId);
            return View(czlonekrodziny);
        }

        //
        // GET: /DodajKrewnego/Delete/5

        public ActionResult Delete(int id = 0)
        {
            CzlonekRodziny czlonekrodziny = db.CzłonekR.Find(id);
            if (czlonekrodziny == null)
            {
                return HttpNotFound();
            }
            return View(czlonekrodziny);
        }

        //
        // POST: /DodajKrewnego/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CzlonekRodziny czlonekrodziny = db.CzłonekR.Find(id);
            db.CzłonekR.Remove(czlonekrodziny);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}