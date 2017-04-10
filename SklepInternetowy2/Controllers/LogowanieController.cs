using SklepInternetowy2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SklepInternetowy2.Controllers
{
    public class LogowanieController : Controller
    {
        private DBContext db = new DBContext();


        // GET: Logowanie
        public ActionResult Zaloguj()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Zaloguj(Klient klient)
        {

            //int czy_jest = db.Klients.Where(k => k.Login == klient.Login).ToList().Count;

            bool czybrak = false;
            bool czyhaslo = false;
            Klient zalogowany = new Klient();
            //sprawdzanie czy login juz wystąpił
            try
            {

                List<Klient> lista = db.Klients.Where(u => u.Login == klient.Login).ToList();

                zalogowany = lista.First();

                czyhaslo = (zalogowany.Haslo == klient.Haslo);
            }
            catch (Exception e)
            {
                czybrak = true;
            }

            if (ModelState.IsValid && !czybrak && czyhaslo)
            {
                Session["zalogowany"] = zalogowany;

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(klient);
            }

            
        }


        public ActionResult Rejestracja()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Rejestracja(Klient klient)
        {

            int czy_zajęty_login = db.Klients.Where(k => k.Login == klient.Login).ToList().Count;


            if(ModelState.IsValid && czy_zajęty_login==0)
            {
                db.Klients.Add(klient);
                db.SaveChanges();

                return RedirectToAction("Index","Home");
            }
            else
            {
                return View(klient);
            }
            
        }


        public ActionResult Wyloguj()
        {
            Session.Clear();

            return View();
        }
    }
}