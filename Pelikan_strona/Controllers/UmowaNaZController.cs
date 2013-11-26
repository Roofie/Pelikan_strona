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
    public class UmowaNaZController : Controller
    {
        private UsersContext db = new UsersContext();

        //
        // GET: /UmowaNaZ/

        public ActionResult Index()
        {
            var user = db.UserProfiles.Single(u => u.UserName == User.Identity.Name).UserId;
            var umowy = db.Umowy.Include(u => u.CzlonekRodziny).Include(u => u.UserProfile).Include(u => u.NaŻycie).Include(u => u.OdziałAgencji).Include(u => u.Turystyczne).Where(u => u.UserId == user).Where(u => u.TurystyczneId == null);
            return View(umowy.ToList());
        }
       

        public ActionResult PolisyTurystyczneKlient()
        {

            var user = db.UserProfiles.Single(u => u.UserName == User.Identity.Name).UserId;
            //var umowy = db.Umowy.Include(u => u.UserId).Include(u => u.OdziałAgencji).Include(u => u.Turystyczne).Where(u => u.UserId == user);
            var umowy = db.Umowy.Include(u => u.CzlonekRodziny).Include(u => u.UserProfile).Include(u => u.NaŻycie).Include(u => u.OdziałAgencji).Include(u => u.Turystyczne).Where(u => u.UserId == user).Where(u=>u.TurystyczneId!=null);
            return PartialView(umowy.ToList());
        }
        //
        // GET: /UmowaNaZ/Details/5

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
        // GET: /UmowaNaZ/Create

        public ActionResult Create(NaŻycie na,Turystyczne tur)
        {
           ViewBag.CzlonekRodzinyId = new SelectList(db.CzłonekR, "CzlonekRodzinyId", "Imie","Nazwisko");
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName");
            if (na.NaŻycieId == 0)
            {
                ViewBag.NaŻycieId = null;
            }
            else {
                ViewBag.NaŻycieId = na.NaŻycieId;
            }
            
            ViewBag.OdziałAgencjiId = new SelectList(db.Odzial, "OdziałAgencjiId", "Miasto");
           // ViewBag.TurystyczneId = new SelectList(db.UTurystyczne, "TurystyczneId", "TurystyczneId");
            if (tur.TurystyczneId == 0)
            {
                ViewBag.TurystyczneId = null;
            }
            else
            {
                ViewBag.TurystyczneId = tur.TurystyczneId;
            }
            return View();
        }

        //
       
       
        // POST: /UmowaNaZ/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UmowaUbezpieczeniowa umowaubezpieczeniowa )
        {
            if (ModelState.IsValid)
            {
               
                umowaubezpieczeniowa.UserId = db.UserProfiles.Single(u => u.UserName == User.Identity.Name).UserId;
                umowaubezpieczeniowa.User_Pesel = db.UserProfiles.Single(u => u.UserName == User.Identity.Name).User_Pesel;
                db.Umowy.Add(umowaubezpieczeniowa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CzlonekRodzinyId = new SelectList(db.CzłonekR, "CzlonekRodzinyId", "Czl_Pesel", umowaubezpieczeniowa.CzlonekRodzinyId);
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", umowaubezpieczeniowa.UserId);
            ViewBag.NaŻycieId = new SelectList(db.NaZ, "NaŻycieId", "NaŻycieId", umowaubezpieczeniowa.NaŻycieId);
            ViewBag.OdziałAgencjiId = new SelectList(db.Odzial, "OdziałAgencjiId", "Miasto", umowaubezpieczeniowa.OdziałAgencjiId);
            ViewBag.TurystyczneId = new SelectList(db.UTurystyczne, "TurystyczneId", "TurystyczneId", umowaubezpieczeniowa.TurystyczneId);
            return View(umowaubezpieczeniowa);
        }


        //
        // GET: /UmowaNaZ/Edit/5

        public ActionResult Edit(int id = 0)
        {
            UmowaUbezpieczeniowa umowaubezpieczeniowa = db.Umowy.Find(id);
            if (umowaubezpieczeniowa == null)
            {
                return HttpNotFound();
            }
            ViewBag.CzlonekRodzinyId = new SelectList(db.CzłonekR, "CzlonekRodzinyId", "Czl_Pesel", umowaubezpieczeniowa.CzlonekRodzinyId);
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", umowaubezpieczeniowa.UserId);
            ViewBag.NaŻycieId = new SelectList(db.NaZ, "NaŻycieId", "NaŻycieId", umowaubezpieczeniowa.NaŻycieId);
            ViewBag.OdziałAgencjiId = new SelectList(db.Odzial, "OdziałAgencjiId", "Miasto", umowaubezpieczeniowa.OdziałAgencjiId);
            ViewBag.TurystyczneId = new SelectList(db.UTurystyczne, "TurystyczneId", "TurystyczneId", umowaubezpieczeniowa.TurystyczneId);
            return View(umowaubezpieczeniowa);
        }

        //
        // POST: /UmowaNaZ/Edit/5

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
            ViewBag.CzlonekRodzinyId = new SelectList(db.CzłonekR, "CzlonekRodzinyId", "Czl_Pesel", umowaubezpieczeniowa.CzlonekRodzinyId);
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", umowaubezpieczeniowa.UserId);
            ViewBag.NaŻycieId = new SelectList(db.NaZ, "NaŻycieId", "NaŻycieId", umowaubezpieczeniowa.NaŻycieId);
            ViewBag.OdziałAgencjiId = new SelectList(db.Odzial, "OdziałAgencjiId", "Miasto", umowaubezpieczeniowa.OdziałAgencjiId);
            ViewBag.TurystyczneId = new SelectList(db.UTurystyczne, "TurystyczneId", "TurystyczneId", umowaubezpieczeniowa.TurystyczneId);
            return View(umowaubezpieczeniowa);
        }

        //
        // GET: /UmowaNaZ/Delete/5

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
        // POST: /UmowaNaZ/Delete/5

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