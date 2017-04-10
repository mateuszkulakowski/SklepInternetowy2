using SklepInternetowy2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SklepInternetowy2.Controllers
{
    public class HomeController : Controller
    {
        private DBContext db = new DBContext();
        public ActionResult Index()
        {

            var listaProduktow = db.Produkts.ToList();

            return View(listaProduktow);
        }

    }
}