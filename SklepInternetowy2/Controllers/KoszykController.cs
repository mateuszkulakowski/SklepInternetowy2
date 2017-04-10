using SklepInternetowy2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SklepInternetowy2.Controllers
{
    public class KoszykController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Koszyk
        public ActionResult Lista()
        {
            return View();
        }

        public ActionResult WybieranieIlości(int? id)
        {
            var zalogowany = Session["zalogowany"] as Klient;

            if (zalogowany == null) return RedirectToAction("NieZalogowany","Error");
            if (id == null) return RedirectToAction("BrakID", "Error");

            Produkt produkt = db.Produkts.Find(id);

            if (produkt == null) return RedirectToAction("NieMaTakiegoProduktu", "Error");

            ViewBag.Ilosc = produkt.Ilość;
            return View(produkt);

        }


        [HttpPost]
        public ActionResult WybieranieIlości(Produkt produkt, FormCollection formCollection)
        {
            String liczba = formCollection["wybranaIlosc"];

            int.Parse(liczba);

            if(Session["koszyk"] == null)
            {
                List<Produkt> koszyk = new List<Produkt>();
                Produkt pomocnik = db.Produkts.Find(produkt.ProduktID);
                pomocnik.Ilość = int.Parse(liczba);//produkty w koszyku mają ilość taką jaką chcemy zamawiac
                koszyk.Add(pomocnik);

                Session["koszyk"] = koszyk;
            }
            else
            {
                List<Produkt> koszyk = Session["koszyk"] as List<Produkt>;
                Produkt pomocnik = db.Produkts.Find(produkt.ProduktID);
                pomocnik.Ilość = int.Parse(liczba);//produkty w koszyku mają ilość taką jaką chcemy zamawiac
                koszyk.Add(pomocnik);

                Session["koszyk"] = koszyk;
            }
            


            return RedirectToAction("Index","Home");
        }

        public ActionResult Szczegóły(int? id)
        {
            var zalogowany = Session["zalogowany"] as Klient;
            var koszyk = Session["koszyk"] as List<Produkt>;

            if(zalogowany == null) return RedirectToAction("NieZalogowany", "Error");
            if(koszyk == null) return RedirectToAction("BrakPrzedmiotowWKoszyku", "Error");
            if (id == null) return RedirectToAction("BrakID", "Error");

            Produkt klikniety = null; 

            foreach(Produkt produkt in koszyk)
            {
                if(produkt.ProduktID == id)
                {
                    klikniety = produkt;
                    break;
                }
            }


            if (klikniety == null) return RedirectToAction("NieMaTakiegoProduktu", "Error");

            return View(klikniety);

        }

        public ActionResult Usuń(int? id)
        {
            var zalogowany = Session["zalogowany"] as Klient;
            var koszyk = Session["koszyk"] as List<Produkt>;

            if (zalogowany == null) return RedirectToAction("NieZalogowany", "Error");
            if (koszyk == null) return RedirectToAction("BrakPrzedmiotowWKoszyku", "Error");
            if (id == null) return RedirectToAction("BrakID", "Error");


            foreach(Produkt produkt in koszyk)
            {
                if(produkt.ProduktID == id)
                {
                    koszyk.Remove(produkt);
                    break;
                }
            }

            return RedirectToAction("Index", "Home");
        }
    }
}