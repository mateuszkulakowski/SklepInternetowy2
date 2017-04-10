using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SklepInternetowy2.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult NieZalogowany()
        {
            return View();
        }

        public ActionResult BrakOdpowiedniejRoli()
        {
            return View();
        }

        public ActionResult BrakID()
        {
            return View();
        }

        public ActionResult NieMaTakiegoProduktu()
        {
            return View();
        }

        public ActionResult BrakPrzedmiotowWKoszyku()
        {
            return View();
        }

    }
}