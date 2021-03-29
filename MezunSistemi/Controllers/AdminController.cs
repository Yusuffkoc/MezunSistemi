using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MezunSistemi.Models;

using System.Data;
using System.Data.Entity;
using System.Net;


namespace MezunSistemi.Controllers
{
    public class AdminController : Controller
    {
        Models.MezunSistemiEntities dbdeneme = new Models.MezunSistemiEntities();
        Models.Mezunlar dbMezunlar= new Models.Mezunlar();
        public ActionResult Index()
        {
            MezunSistemiEntities dbConnect = new MezunSistemiEntities();
            var mezunlar = dbConnect.Mezunlar.ToList();
            return View(mezunlar);
            
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Kayit()
        {
            return View();
        }


        public ActionResult AnketYukle()
        {
            return View();
        }
        
        
        [HttpPost]
        public ActionResult Login(Mezunlar mezun)
        {
            var kullanici=dbdeneme.Mezunlar.FirstOrDefault( x=> x.Okul_Numarasi == mezun.Okul_Numarasi && x.Sifre == mezun.Sifre);
            if (kullanici != null)
            {
                Session["Okul_Numarasi"] = kullanici;//içerde biri varsa tekrar giriş yaptırmasın.

                return RedirectToAction("MezunIndex", "Mezunlar");

            }
            ViewBag.Uyari("Kullanıcı Adı Veya Şifre Yanlış...");
            return View(mezun);
        }

    }
}