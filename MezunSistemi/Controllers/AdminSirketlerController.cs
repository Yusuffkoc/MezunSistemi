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
    public class AdminSirketlerController : Controller
    {
        private MezunSistemiEntities db = new MezunSistemiEntities();

        // GET: AdminSirketler
        public ActionResult Index()
        {
            return View(db.Sirketler.ToList());
        }

        // GET: AdminSirketler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sirketler sirketler = db.Sirketler.Find(id);
            if (sirketler == null)
            {
                return HttpNotFound();
            }
            return View(sirketler);
        }

        // GET: AdminSirketler/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminSirketler/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Sirket_Id,Sirket_Adi,Adres,Sirket_TelNo,Sirket_Mail")] Sirketler sirketler)
        {
            if (ModelState.IsValid)
            {
                db.Sirketler.Add(sirketler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sirketler);
        }

        // GET: AdminSirketler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sirketler sirketler = db.Sirketler.Find(id);
            if (sirketler == null)
            {
                return HttpNotFound();
            }
            return View(sirketler);
        }

        // POST: AdminSirketler/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Sirket_Id,Sirket_Adi,Adres,Sirket_TelNo,Sirket_Mail")] Sirketler sirketler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sirketler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sirketler);
        }

        // GET: AdminSirketler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sirketler sirketler = db.Sirketler.Find(id);
            if (sirketler == null)
            {
                return HttpNotFound();
            }
            return View(sirketler);
        }

        // POST: AdminSirketler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sirketler sirketler = db.Sirketler.Find(id);
            db.Sirketler.Remove(sirketler);
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
