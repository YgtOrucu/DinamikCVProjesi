using DinamikCVProjesi.Models.Entity;
using DinamikCVProjesi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

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
        [HttpGet]
        public ActionResult HakkımdaGetir(int id)
        {
            var hakkımdadetails = hakkımda.TGetID(id);
            ViewBag.Durum = new List<SelectListItem>
            {
                new SelectListItem { Value = "True", Text = "Aktif" },
                new SelectListItem { Value = "False", Text = "Pasif" }
            };
            return View("HakkımdaGetir", hakkımdadetails);
        }
        [HttpPost]
        public ActionResult HakkımdaGüncelle(TBL_Hakkımda h)
        {
            var updatedvalues = hakkımda.TGetID(h.ID);
            updatedvalues.AD = h.AD;
            updatedvalues.SOYAD = h.SOYAD;
            updatedvalues.ADRES = h.ADRES;
            updatedvalues.TELEFON = h.TELEFON;
            updatedvalues.MAİL = h.MAİL;
            updatedvalues.ACIKLAMA = h.ACIKLAMA;
            updatedvalues.DURUM = h.DURUM;

            hakkımda.TUpdate(updatedvalues);
            return RedirectToAction("Hakkımda");
        }

        public ActionResult HakkımdaSil(int id)
        {
            var deletedvalues = deneyimler.TGetID(id);
            deneyimler.TDelete(deletedvalues);
            return RedirectToAction("Hakkımda");
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
            ViewBag.Durum = new List<SelectListItem>
            {
                new SelectListItem { Value = "True", Text = "Aktif" },
                new SelectListItem { Value = "False", Text = "Pasif" }
            };

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

            ViewBag.Durum = new List<SelectListItem>
            {
                new SelectListItem { Value = "false", Text = "Pasif", Selected = selectedıtem.DURUM != true },
                new SelectListItem { Value = "true", Text = "Aktif",Selected = selectedıtem.DURUM != false}
            };
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
            getıtem.DURUM = d.DURUM;

            deneyimler.TUpdate(getıtem);
            return RedirectToAction("Deneyim");
        }
        #endregion
    }
}