using SklepInternetowy2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SklepInternetowy2.Controllers
{
    public class ProduktController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Produkt
        public ActionResult Dodaj()
        {
            var zalogowany = Session["zalogowany"] as Klient;

            if (zalogowany == null) return RedirectToAction("NieZalogowany", "Error");
            if (zalogowany.Login.Equals("Admin")) return RedirectToAction("BrakOdpowiedniejRoli", "Error");

            //lista kategorie i producenci

            var listaKategorii = db.Categories.ToList();
            var listaProducentów = db.Producents.ToList();

            ViewData["ProducentID"] = new SelectList(listaProducentów, "ProducentID", "Nazwa");
            ViewData["CategoryID"] = new SelectList(listaKategorii, "CategoryID", "Nazwa");

            return View();
        }


        [HttpPost]
        public ActionResult Dodaj(Produkt produkt)
        {
            if(ModelState.IsValid)
            {
                db.Produkts.Add(produkt);
                db.SaveChanges();

                return RedirectToAction("Index", "Home");
            }

            var listaKategorii = db.Categories.ToList();
            var listaProducentów = db.Producents.ToList();

            ViewData["ProducentID"] = new SelectList(listaProducentów, "ProducentID", "Nazwa");
            ViewData["CategoryID"] = new SelectList(listaKategorii, "CategoryID", "Nazwa");


            return View(produkt);
        }

        public ActionResult Usuń(int? id)
        {
            var zalogowany = Session["zalogowany"] as Klient;

            
            if (zalogowany == null) return RedirectToAction("NieZalogowany", "Error");//czy zalogowany
            if (!zalogowany.Login.Equals("admin")) return RedirectToAction("BrakOdpowiedniejRoli", "Error");
            if (id == null) return RedirectToAction("BrakID", "Error");

            Produkt produkt = db.Produkts.Find(id);

            if (produkt == null) return RedirectToAction("NieMaTakiegoProduktu", "Error");

            return View(produkt);
        }

        [HttpPost]
        public ActionResult Usuń(int id)
        {
            Produkt produkt = db.Produkts.Find(id);

            db.Produkts.Remove(produkt);
            db.SaveChanges();

            return RedirectToAction("Index","Home");
        }


        public ActionResult Szczegóły(int? id)
        {
            var zalogowany = Session["zalogowany"] as Klient;
            
            if (id == null) return RedirectToAction("BrakID", "Error");

            Produkt produkt = db.Produkts.Find(id);

            if (produkt == null) return RedirectToAction("NieMaTakiegoProduktu", "Error");

            return View(produkt);
        }
    }
}