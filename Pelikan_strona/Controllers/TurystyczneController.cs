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
    public class TurystyczneController : Controller
    {
        private UsersContext db = new UsersContext();

        //
        // GET: /Turystyczne/

        public ActionResult Index()
        {
            var uturystyczne = db.UTurystyczne.Include(t => t.WariantPolisy);
            return View(uturystyczne.ToList());
        }

        //
        // GET: /Turystyczne/Details/5

        public ActionResult Details(int id = 0)
        {
            Turystyczne turystyczne = db.UTurystyczne.Find(id);
            if (turystyczne == null)
            {
                return HttpNotFound();
            }
            return View(turystyczne);
        }

        public ActionResult Partial1()
        {
            var model = db.Wsriants.ToList();
            
            return PartialView(model);
        }

        

        //
        // GET: /Turystyczne/Create

        public ActionResult Create()
        {
            ViewBag.WariantPolisyId = new SelectList(db.Wsriants, "WariantPolisyId", "NazwaWariantu");
            return View();
        }

        //
        // POST: /Turystyczne/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Turystyczne turystyczne)
        {
            if (ModelState.IsValid)
            {
                db.UTurystyczne.Add(turystyczne);
                db.SaveChanges();
                return RedirectToAction("Create","UmowaNaZ",new { TurystyczneId = turystyczne.TurystyczneId });
            }

            ViewBag.WariantPolisyId = new SelectList(db.Wsriants, "WariantPolisyId", "NazwaWariantu", turystyczne.WariantPolisyId);
            return View(turystyczne);
        }

        //
        // GET: /Turystyczne/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Turystyczne turystyczne = db.UTurystyczne.Find(id);
            if (turystyczne == null)
            {
                return HttpNotFound();
            }
            ViewBag.WariantPolisyId = new SelectList(db.Wsriants, "WariantPolisyId", "NazwaWariantu", turystyczne.WariantPolisyId);
            return View(turystyczne);
        }

        //
        // POST: /Turystyczne/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Turystyczne turystyczne)
        {
            if (ModelState.IsValid)
            {
                db.Entry(turystyczne).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.WariantPolisyId = new SelectList(db.Wsriants, "WariantPolisyId", "NazwaWariantu", turystyczne.WariantPolisyId);
            return View(turystyczne);
        }

        //
        // GET: /Turystyczne/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Turystyczne turystyczne = db.UTurystyczne.Find(id);
            if (turystyczne == null)
            {
                return HttpNotFound();
            }
            return View(turystyczne);
        }

        //
        // POST: /Turystyczne/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Turystyczne turystyczne = db.UTurystyczne.Find(id);
            db.UTurystyczne.Remove(turystyczne);
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