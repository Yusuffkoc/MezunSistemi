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
    public class AdminMezunlarController : Controller
    {
        private MezunSistemiEntities db = new MezunSistemiEntities();

        // GET: AdminMezunlar
        public ActionResult Index()
        {
            var mezunlar = db.Mezunlar.Include(m => m.Sirketler);
            return View(mezunlar.ToList());
        }

        // GET: AdminMezunlar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mezunlar mezunlar = db.Mezunlar.Find(id);
            if (mezunlar == null)
            {
                return HttpNotFound();
            }
            return View(mezunlar);
        }

        // GET: AdminMezunlar/Create
        public ActionResult Create()
        {
            ViewBag.Sirket_Id = new SelectList(db.Sirketler, "Sirket_Id", "Sirket_Adi");
            return View();
        }

        // POST: AdminMezunlar/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Mezun_Id,Ad,Soyad,TC,Tel_No,Egitim_Bilgisi,Yabanci_Dil,Sertifika_Bilgisi,Mezuniyet_Yili,Sirket_Id,Calisma_Durumu,Sifre,Okul_Numarasi")] Mezunlar mezunlar)
        {
            if (ModelState.IsValid)
            {
                db.Mezunlar.Add(mezunlar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Sirket_Id = new SelectList(db.Sirketler, "Sirket_Id", "Sirket_Adi", mezunlar.Sirket_Id);
            return View(mezunlar);
        }

        // GET: AdminMezunlar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mezunlar mezunlar = db.Mezunlar.Find(id);
            if (mezunlar == null)
            {
                return HttpNotFound();
            }
            ViewBag.Sirket_Id = new SelectList(db.Sirketler, "Sirket_Id", "Sirket_Adi", mezunlar.Sirket_Id);
            return View(mezunlar);
        }

        // POST: AdminMezunlar/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Mezun_Id,Ad,Soyad,TC,Tel_No,Egitim_Bilgisi,Yabanci_Dil,Sertifika_Bilgisi,Mezuniyet_Yili,Sirket_Id,Calisma_Durumu,Sifre,Okul_Numarasi")] Mezunlar mezunlar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mezunlar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Sirket_Id = new SelectList(db.Sirketler, "Sirket_Id", "Sirket_Adi", mezunlar.Sirket_Id);
            return View(mezunlar);
        }

        // GET: AdminMezunlar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mezunlar mezunlar = db.Mezunlar.Find(id);
            if (mezunlar == null)
            {
                return HttpNotFound();
            }
            return View(mezunlar);
        }

        // POST: AdminMezunlar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mezunlar mezunlar = db.Mezunlar.Find(id);
            db.Mezunlar.Remove(mezunlar);
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
