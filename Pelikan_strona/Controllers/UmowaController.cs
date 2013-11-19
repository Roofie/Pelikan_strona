using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pelikan_strona.Models;
using WebMatrix.WebData;

namespace Pelikan_strona.Controllers
{
    public class UmowaController : Controller
    {
        private UsersContext db = new UsersContext();

        //
        // GET: /Umowa/

        public ActionResult Index()
        {
            var umowy = db.Umowy.Include(u => u.UserProfile).Include(u => u.NaŻycie).Include(u => u.OdziałAgencji).Include(u => u.Szkoda).Include(u => u.Turystyczne);
            return View(umowy.ToList());
        }

        //
        // GET: /Umowa/Details/5

        public ActionResult Details(int id = 0)
        {
            UmowaUbezpieczeniowa umowaubezpieczeniowa = db.Umowy.Find(id);
            if (umowaubezpieczeniowa == null)
            {
                return HttpNotFound();
            }
            return View(umowaubezpieczeniowa);
        }

        //
        // GET: /Umowa/Create
        [Authorize]
        public ActionResult Create()
        {
            
            ViewBag.NaŻycieId = new SelectList(db.NaZ, "NaŻycieId", "NaŻycieId");
            ViewBag.OdziałAgencjiId = new SelectList(db.Odzial, "OdziałAgencjiId", "Miasto");
            ViewBag.SzkodaId = new SelectList(db.Szkody, "SzkodaId", "Opis");
            ViewBag.TurystyczneId = new SelectList(db.UTurystyczne, "TurystyczneId", "TurystyczneId");
            return View();
        }

        //
        // POST: /Umowa/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UmowaUbezpieczeniowa umowaubezpieczeniowa)

        {
            umowaubezpieczeniowa.UserId = db.UserProfiles.Single(u => u.UserName == User.Identity.Name).UserId;
            umowaubezpieczeniowa.Pesel = db.UserProfiles.Single(u => u.UserName == User.Identity.Name).Pesel;
            if (ModelState.IsValid)
            {
                
                
                db.Umowy.Add(umowaubezpieczeniowa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            ViewBag.NaŻycieId = new SelectList(db.NaZ, "NaŻycieId", "NaŻycieId", umowaubezpieczeniowa.NaŻycieId);
            ViewBag.OdziałAgencjiId = new SelectList(db.Odzial, "OdziałAgencjiId", "Miasto", umowaubezpieczeniowa.OdziałAgencjiId);
            ViewBag.SzkodaId = new SelectList(db.Szkody, "SzkodaId", "Opis", umowaubezpieczeniowa.SzkodaId);
            ViewBag.TurystyczneId = new SelectList(db.UTurystyczne, "TurystyczneId", "TurystyczneId", umowaubezpieczeniowa.TurystyczneId);
            return View(umowaubezpieczeniowa);
        }

        //
        // GET: /Umowa/Edit/5

        public ActionResult Edit(int id = 0)
        {
            UmowaUbezpieczeniowa umowaubezpieczeniowa = db.Umowy.Find(id);
            if (umowaubezpieczeniowa == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", umowaubezpieczeniowa.UserId);
            ViewBag.NaŻycieId = new SelectList(db.NaZ, "NaŻycieId", "NaŻycieId", umowaubezpieczeniowa.NaŻycieId);
            ViewBag.OdziałAgencjiId = new SelectList(db.Odzial, "OdziałAgencjiId", "Miasto", umowaubezpieczeniowa.OdziałAgencjiId);
            ViewBag.SzkodaId = new SelectList(db.Szkody, "SzkodaId", "Opis", umowaubezpieczeniowa.SzkodaId);
            ViewBag.TurystyczneId = new SelectList(db.UTurystyczne, "TurystyczneId", "TurystyczneId", umowaubezpieczeniowa.TurystyczneId);
            return View(umowaubezpieczeniowa);
        }

        //
        // POST: /Umowa/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UmowaUbezpieczeniowa umowaubezpieczeniowa)
        {
            if (ModelState.IsValid)
            {
                
                db.Entry(umowaubezpieczeniowa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", umowaubezpieczeniowa.UserId);
            ViewBag.NaŻycieId = new SelectList(db.NaZ, "NaŻycieId", "NaŻycieId", umowaubezpieczeniowa.NaŻycieId);
            ViewBag.OdziałAgencjiId = new SelectList(db.Odzial, "OdziałAgencjiId", "Miasto", umowaubezpieczeniowa.OdziałAgencjiId);
            ViewBag.SzkodaId = new SelectList(db.Szkody, "SzkodaId", "Opis", umowaubezpieczeniowa.SzkodaId);
            ViewBag.TurystyczneId = new SelectList(db.UTurystyczne, "TurystyczneId", "TurystyczneId", umowaubezpieczeniowa.TurystyczneId);
            return View(umowaubezpieczeniowa);
        }

        //
        // GET: /Umowa/Delete/5

        public ActionResult Delete(int id = 0)
        {
            UmowaUbezpieczeniowa umowaubezpieczeniowa = db.Umowy.Find(id);
            if (umowaubezpieczeniowa == null)
            {
                return HttpNotFound();
            }
            return View(umowaubezpieczeniowa);
        }

        //
        // POST: /Umowa/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UmowaUbezpieczeniowa umowaubezpieczeniowa = db.Umowy.Find(id);
            db.Umowy.Remove(umowaubezpieczeniowa);
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