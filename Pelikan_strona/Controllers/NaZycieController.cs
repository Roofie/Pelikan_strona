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
    public class NaZycieController : Controller
    {
        private UsersContext db = new UsersContext();

        //
        // GET: /Default1/

        public ActionResult Index()
        {
            var naz = db.NaZ.Include(n => n.CelUbezpieczeń).Include(n => n.SumaUbezpieczenia).Include(n => n.Zawód);
            return View(naz.ToList());
        }

        //
        // GET: /Default1/Details/5

        public ActionResult Details(int id = 0)
        {
            NaŻycie nażycie = db.NaZ.Find(id);
            if (nażycie == null)
            {
                return HttpNotFound();
            }
            return View(nażycie);
        }

        //
        // GET: /Default1/Create

        public ActionResult Create()
        {
            //var max = db.NaZ.Max(o => o.NaŻycieId);
           // ViewBag.NaŻycieId = max + 1;
            ViewBag.CelUbezpieczeńId = new SelectList(db.CelU, "CelUbezpieczeńId", "NazwaCelu");
            ViewBag.SumaUbezpieczeniaId = new SelectList(db.Sumy, "SumaUbezpieczeniaId", "Kwota");
            ViewBag.ZawódId = new SelectList(db.Zawody, "ZawódId", "NazwaZawodu");
            return View();
        }

        //
        // POST: /Default1/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NaŻycie nażycie)
        {
            if (ModelState.IsValid)
            {
                
                db.NaZ.Add(nażycie);
                db.SaveChanges();
                return RedirectToAction("Create", "UmowaNaZ", new { NaŻycieId = nażycie.NaŻycieId });
            }

            ViewBag.NaŻycieId = nażycie.NaŻycieId ;
            ViewBag.CelUbezpieczeńId = new SelectList(db.CelU, "CelUbezpieczeńId", "NazwaCelu", nażycie.CelUbezpieczeńId);
            ViewBag.SumaUbezpieczeniaId = new SelectList(db.Sumy, "SumaUbezpieczeniaId", "Kwota", nażycie.SumaUbezpieczeniaId);
            ViewBag.ZawódId = new SelectList(db.Zawody, "ZawódId", "NazwaZawodu", nażycie.ZawódId);
            return View(nażycie);
        }

        //
        // GET: /Default1/Edit/5

        public ActionResult Edit(int id = 0)
        {
            NaŻycie nażycie = db.NaZ.Find(id);
            if (nażycie == null)
            {
                return HttpNotFound();
            }
            ViewBag.CelUbezpieczeńId = new SelectList(db.CelU, "CelUbezpieczeńId", "NazwaCelu", nażycie.CelUbezpieczeńId);
            ViewBag.SumaUbezpieczeniaId = new SelectList(db.Sumy, "SumaUbezpieczeniaId", "SumaUbezpieczeniaId", nażycie.SumaUbezpieczeniaId);
            ViewBag.ZawódId = new SelectList(db.Zawody, "ZawódId", "NazwaZawodu", nażycie.ZawódId);
            return View(nażycie);
        }

        //
        // POST: /Default1/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NaŻycie nażycie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nażycie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CelUbezpieczeńId = new SelectList(db.CelU, "CelUbezpieczeńId", "NazwaCelu", nażycie.CelUbezpieczeńId);
            ViewBag.SumaUbezpieczeniaId = new SelectList(db.Sumy, "SumaUbezpieczeniaId", "SumaUbezpieczeniaId", nażycie.SumaUbezpieczeniaId);
            ViewBag.ZawódId = new SelectList(db.Zawody, "ZawódId", "NazwaZawodu", nażycie.ZawódId);
            return View(nażycie);
        }

        //
        // GET: /Default1/Delete/5

        public ActionResult Delete(int id = 0)
        {
            NaŻycie nażycie = db.NaZ.Find(id);
            if (nażycie == null)
            {
                return HttpNotFound();
            }
            return View(nażycie);
        }

        //
        // POST: /Default1/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NaŻycie nażycie = db.NaZ.Find(id);
            db.NaZ.Remove(nażycie);
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