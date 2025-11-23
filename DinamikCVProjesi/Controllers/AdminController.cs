using DinamikCVProjesi.Models.Entity;
using DinamikCVProjesi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DinamikCVProjesi.Controllers
{
    public class AdminController : Controller
    {
        #region HakkımdaBölümü
        HakkımdaRepository hakkımda = new HakkımdaRepository();
        public ActionResult Hakkımda()
        {
            var values = hakkımda.List();
            return View(values);
        }
        #endregion

        #region DeneyimlerBölümü
        DeneyimlerRepository deneyimler = new DeneyimlerRepository();
        public ActionResult Deneyim()
        {
            var values = deneyimler.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult DeneyimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeneyimEkle(TBL_Deneyimler d)
        {
            deneyimler.TAdd(d);
            return RedirectToAction("Deneyim");
        }

        public ActionResult DeneyimSil(int id)
        {
            var deletedvalues = deneyimler.TGetID(id);
            deneyimler.TDelete(deletedvalues);
            return RedirectToAction("Deneyim");
        }

        [HttpGet]
        public ActionResult DeneyimGetir(int id)
        {
            var selectedıtem = deneyimler.TGetID(id);
            return View("DeneyimGetir", selectedıtem);
        }
        [HttpPost]
        public ActionResult DeneyimGüncelle(TBL_Deneyimler d)
        {
            var getıtem = deneyimler.TGetID(d.ID);
            getıtem.BASLIK = d.BASLIK;
            getıtem.ALTBASLIK = d.ALTBASLIK;
            getıtem.ACIKLAMA = d.ACIKLAMA;
            getıtem.TARİH = d.TARİH;
            getıtem.Kullanılan_Diller = d.Kullanılan_Diller;

            deneyimler.TUpdate(getıtem);
            return RedirectToAction("Deneyim");
        }
        #endregion
    }
}