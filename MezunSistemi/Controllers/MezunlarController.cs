using MezunSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MezunSistemi.Controllers
{
    public class MezunlarController : Controller
    {
        MezunSistemiEntities db = new MezunSistemiEntities();

        // GET: Mezunlar
        public ActionResult Anasayfa()
        {
            
            var mezunlar = db.Mezunlar.ToList();
            return View(mezunlar);
        }

       
        public ActionResult MezunIndex()
        {

            return View();
        }

        public ActionResult Arkadaslar()
        {
            return View();

        }

        public ActionResult Sirketim()
        {
            return View();
        }

        public ActionResult Anketlerim()
        {
            return View();
        }

        public ActionResult Profilim()
        {
            return View();
        }
    }
}