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
    public class WiadomosciController : Controller
    {
        private UsersContext db = new UsersContext();

        //
        // GET: /Wiadomosci/

        public ActionResult Index()
        {
            var wiadomość = db.Wiadomość.Include(w => w.UserProfile).Include(w => w.Pracownik);
            return View(wiadomość.ToList());
        }

        //
        // GET: /Wiadomosci/Details/5

        public ActionResult Details(int id = 0)
        {
            Wiadomości wiadomości = db.Wiadomość.Find(id);
            if (wiadomości == null)
            {
                return HttpNotFound();
            }
            return View(wiadomości);
        }

        //
        // GET: /Wiadomosci/Create

        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName");
            ViewBag.PracownikId = new SelectList(db.Pracownicy, "PracownikId", "Pesel");
            return View();
        }

        //
        // POST: /Wiadomosci/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Wiadomości wiadomości)
        {
            if (ModelState.IsValid)
            {
                db.Wiadomość.Add(wiadomości);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", wiadomości.UserId);
            ViewBag.PracownikId = new SelectList(db.Pracownicy, "PracownikId", "Pesel", wiadomości.PracownikId);
            return View(wiadomości);
        }

        //
        // GET: /Wiadomosci/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Wiadomości wiadomości = db.Wiadomość.Find(id);
            if (wiadomości == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", wiadomości.UserId);
            ViewBag.PracownikId = new SelectList(db.Pracownicy, "PracownikId", "Pesel", wiadomości.PracownikId);
            return View(wiadomości);
        }

        //
        // POST: /Wiadomosci/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Wiadomości wiadomości)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wiadomości).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", wiadomości.UserId);
            ViewBag.PracownikId = new SelectList(db.Pracownicy, "PracownikId", "Pesel", wiadomości.PracownikId);
            return View(wiadomości);
        }

        //
        // GET: /Wiadomosci/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Wiadomości wiadomości = db.Wiadomość.Find(id);
            if (wiadomości == null)
            {
                return HttpNotFound();
            }
            return View(wiadomości);
        }

        //
        // POST: /Wiadomosci/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Wiadomości wiadomości = db.Wiadomość.Find(id);
            db.Wiadomość.Remove(wiadomości);
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