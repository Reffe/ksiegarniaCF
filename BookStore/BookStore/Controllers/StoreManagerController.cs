using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;


namespace BookStore.Controllers
{
    [Authorize(Roles = "Admin")]
    public class StoreManagerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        

        
        public ViewResult Index()
        {
            
            var ksiazki = db.Ksiazki.Include(k => k.Autor).Include(k => k.Gatunek).OrderBy(k => k.Cena);
            return View(ksiazki.ToList());
        }

        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ksiazka ksiazka = db.Ksiazki.Find(id);
            if (ksiazka == null)
            {
                return HttpNotFound();
            }
            return View(ksiazka);
        }

        
        public ActionResult Create()
        {
            ViewBag.AutorId = new SelectList(db.Autor, "AutorId", "Imie");
            ViewBag.GatunekId = new SelectList(db.Gatunki, "GatunekId", "Nazwa");
            return View();
        }

        // POST: StoreManager/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KsiazkaId,GatunekId,AutorId,Imie,Tytul,Cena,Opis,KsiazkaLogo")] Ksiazka ksiazka)
        {
            if (ModelState.IsValid)
            {
                db.Ksiazki.Add(ksiazka);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AutorId = new SelectList(db.Autor, "AutorId", "Imie", ksiazka.AutorId);
            ViewBag.GatunekId = new SelectList(db.Gatunki, "GatunekId", "Nazwa", ksiazka.GatunekId);
            return View(ksiazka);
        }

        // GET: StoreManager/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ksiazka ksiazka = db.Ksiazki.Find(id);
            if (ksiazka == null)
            {
                return HttpNotFound();
            }
            ViewBag.AutorId = new SelectList(db.Autor, "AutorId", "Imie", ksiazka.AutorId);
            ViewBag.GatunekId = new SelectList(db.Gatunki, "GatunekId", "Nazwa", ksiazka.GatunekId);
            return View(ksiazka);
        }

        // POST: StoreManager/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KsiazkaId,GatunekId,AutorId,Tytul,Cena,Opis,KsiazkaLogo")] Ksiazka ksiazka)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ksiazka).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AutorId = new SelectList(db.Autor, "AutorId", "Imie", ksiazka.AutorId);
            ViewBag.GatunekId = new SelectList(db.Gatunki, "GatunekId", "Nazwa", ksiazka.GatunekId);
            return View(ksiazka);
        }

        // GET: StoreManager/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ksiazka ksiazka = db.Ksiazki.Find(id);
            if (ksiazka == null)
            {
                return HttpNotFound();
            }
            return View(ksiazka);
        }

        // POST: StoreManager/Delete/5
        [HttpPost, ActionName("Delete")]
        
        public ActionResult DeleteConfirmed(int id)
        {
            Ksiazka ksiazka = db.Ksiazki.Find(id);
            db.Ksiazki.Remove(ksiazka);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CreateAutor()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Admin")]
        public ActionResult CreateAutor([Bind(Include = "AutorId,Imie")] Autor autorzy)
        {
            if (ModelState.IsValid)
            {
                db.Autor.Add(autorzy);
                 db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(autorzy);
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
