using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MezunSistemi.Models;

namespace MezunSistemi.Controllers
{
    public class AdminilanlarController : Controller
    {
        private MezunSistemiEntities db = new MezunSistemiEntities();

        // GET: Adminilanlar
        public ActionResult Index()
        {
            var ilanlar = db.Ilanlar.Include(i => i.Sirketler);
            return View(ilanlar.ToList());
        }

        // GET: Adminilanlar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ilanlar ilanlar = db.Ilanlar.Find(id);
            if (ilanlar == null)
            {
                return HttpNotFound();
            }
            return View(ilanlar);
        }

        // GET: Adminilanlar/Create
        public ActionResult Create()
        {
            ViewBag.Sirket_Id = new SelectList(db.Sirketler, "Sirket_Id", "Sirket_Adi");
            return View();
        }

        // POST: Adminilanlar/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Ilan_Id,Sirket_Id,Icerik_Baslik,Icerik,Tarih,Ilan_Tipi")] Ilanlar ilanlar)
        {
            if (ModelState.IsValid)
            {
                db.Ilanlar.Add(ilanlar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Sirket_Id = new SelectList(db.Sirketler, "Sirket_Id", "Sirket_Adi", ilanlar.Sirket_Id);
            return View(ilanlar);
        }

        // GET: Adminilanlar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ilanlar ilanlar = db.Ilanlar.Find(id);
            if (ilanlar == null)
            {
                return HttpNotFound();
            }
            ViewBag.Sirket_Id = new SelectList(db.Sirketler, "Sirket_Id", "Sirket_Adi", ilanlar.Sirket_Id);
            return View(ilanlar);
        }

        // POST: Adminilanlar/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Ilan_Id,Sirket_Id,Icerik_Baslik,Icerik,Tarih,Ilan_Tipi")] Ilanlar ilanlar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ilanlar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Sirket_Id = new SelectList(db.Sirketler, "Sirket_Id", "Sirket_Adi", ilanlar.Sirket_Id);
            return View(ilanlar);
        }

        // GET: Adminilanlar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ilanlar ilanlar = db.Ilanlar.Find(id);
            if (ilanlar == null)
            {
                return HttpNotFound();
            }
            return View(ilanlar);
        }

        // POST: Adminilanlar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ilanlar ilanlar = db.Ilanlar.Find(id);
            db.Ilanlar.Remove(ilanlar);
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
