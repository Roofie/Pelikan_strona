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
    public class SzkodaController : Controller
    {
        private UsersContext db = new UsersContext();

        //
        // GET: /Szkoda/

        public ActionResult Index()
        {
            var szkody = db.Szkody.Include(s => s.UmowaUbezpieczeniowa);
            return View(szkody.ToList());
        }

        //
        // GET: /Szkoda/Details/5

        public ActionResult Details(int id = 0)
        {
            Szkoda szkoda = db.Szkody.Find(id);
            if (szkoda == null)
            {
                return HttpNotFound();
            }
            return View(szkoda);
        }

        //
        // GET: /Szkoda/Create

        public ActionResult Nowa(int UmowaId)
        {
            
            ViewBag.UmowaId = UmowaId;
            return View();
        }

        //
        // POST: /Szkoda/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Nowa(Szkoda szkoda)
        {
            if (ModelState.IsValid)
            {
                szkoda.DataZgłoszenia = DateTime.Now;
                db.Szkody.Add(szkoda);
                db.SaveChanges();
                return RedirectToAction("DodajZdjecie", new { SzkodaId = szkoda.SzkodaId });
            }

            ViewBag.UmowaId = new SelectList(db.Umowy, "UmowaId", "User_Pesel", szkoda.UmowaId);
            return View(szkoda);
        }

        public ActionResult DodajZdjecie(int SzkodyId=0)
        {
            
            ViewBag.SzkodaId = SzkodyId;
            return View();
        }
        [HttpPost]
        
        public ActionResult DodajZdjecie (Zdjecia z, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                z.DataDodania = DateTime.Now;

                
                if (image != null && image.ContentLength > 0)
                {
                    image.SaveAs(HttpContext.Server.MapPath("~/Images/Uploads")
                                                  + image.FileName);
                    z.SciezkaDoZdjecia = "/Images/Uploads" + image.FileName;
                    
                }
                db.Zdjecias.Add(z);              
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(z);
        }

        public ActionResult SzkodyIZdjęcia(int id = 0)
        {

            var numer = from idS in db.Szkody where idS.UmowaId == id select idS.SzkodaId ;

            System.Diagnostics.Debug.WriteLine(id);                   
            System.Diagnostics.Debug.WriteLine(numer.First());
            if (numer == null)
            {
                return HttpNotFound();
            }
            var szkodaZ = db.Zdjecias.Where(c => c.SzkodaId == numer.First());
            return View(szkodaZ.ToList());
            
        }
       
        //
        // GET: /Szkoda/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Szkoda szkoda = db.Szkody.Find(id);
            if (szkoda == null)
            {
                return HttpNotFound();
            }
            ViewBag.UmowaId = new SelectList(db.Umowy, "UmowaId", "User_Pesel", szkoda.UmowaId);
            return View(szkoda);
        }

        //
        // POST: /Szkoda/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Szkoda szkoda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(szkoda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UmowaId = new SelectList(db.Umowy, "UmowaId", "User_Pesel", szkoda.UmowaId);
            return View(szkoda);
        }

        //
        // GET: /Szkoda/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Szkoda szkoda = db.Szkody.Find(id);
            if (szkoda == null)
            {
                return HttpNotFound();
            }
            return View(szkoda);
        }

        //
        // POST: /Szkoda/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Szkoda szkoda = db.Szkody.Find(id);
            db.Szkody.Remove(szkoda);
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