using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MezunSistemi.Models;

namespace MezunSistemi.Controllers
{
    public class AdminGirisiController : Controller
    {
       

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        // GET: AdminGirisi
        public ActionResult Login(string kAdi, string sifre)
        {

            if (kAdi == "Admin" && sifre == "12345")
            {
                
                return RedirectToAction("Index", "AdminMezunlar");
            }
            else
            {
                return RedirectToAction("Login", "AdminGirisi");
            }

            //try
            //{
            //    if (kAdi == "Admin" && sifre == "12345")
            //    {
            //        Session["adminid"] = "Admin";
            //        Session["sifre"] = "12345";


                //        return RedirectToAction("Index", "AdminMezunlar");
                //    }
                //    else
                //        throw new Exception();
                //}
                //catch (Exception ex)
                //{
                //    ViewBag.Uyari = "Kullanıcı adı ya da şifre Yanlış...";
                //}

                //return RedirectToAction("Index", "AdminMezunlar");
        }


    }
}