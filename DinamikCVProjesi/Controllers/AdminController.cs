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

        #region EKLE
        [HttpGet]
        public ActionResult HakkımdaEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult HakkımdaEkle(TBL_Hakkımda h)
        {
            hakkımda.TAdd(h);
            return RedirectToAction("Hakkımda");
        }

        #endregion

        #region SİL
        public ActionResult HakkımdaSil(int id)
        {
            var deletedvalues = hakkımda.TGetID(id);
            hakkımda.TDelete(deletedvalues);
            return RedirectToAction("Hakkımda");
        }
        #endregion

        #region GÜNCELLE
        [HttpGet]
        public ActionResult HakkımdaGetir(int id)
        {
            var hakkımdadetails = hakkımda.TGetID(id);
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
        #endregion


        #endregion

        #region DeneyimlerBölümü
        DeneyimlerRepository deneyimler = new DeneyimlerRepository();
        public ActionResult Deneyim()
        {
            var values = deneyimler.List();
            return View(values);
        }

        #region EKLE

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

        #endregion

        #region SİL
        public ActionResult DeneyimSil(int id)
        {
            var deletedvalues = deneyimler.TGetID(id);
            deneyimler.TDelete(deletedvalues);
            return RedirectToAction("Deneyim");
        }
        #endregion

        #region GÜNCELLE
        [HttpGet]
        public ActionResult DeneyimGetir(int id)
        {
            var selectedItem = deneyimler.TGetID(id);
            return View("DeneyimGetir", selectedItem);
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

        #endregion

        #region YenetekBölümü
        YetenekRepository yetenek = new YetenekRepository();
        public ActionResult Yetenek()
        {
            var values = yetenek.List();
            return View(values);
        }

        #region EKLE
        [HttpGet]
        public ActionResult YetenekEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YetenekEkle(TBL_Yetenek y)
        {
            yetenek.TAdd(y);
            return RedirectToAction("Yetenek");
        }
        #endregion

        #region Güncelle
        [HttpGet]
        public ActionResult YetenekGetir(int id)
        {
            var getYetenek = yetenek.TGetID(id);
            return View("YetenekGetir", getYetenek);
        }

        [HttpPost]
        public ActionResult YetenekGüncelle(TBL_Yetenek y)
        {
            var updatedValue = yetenek.TGetID(y.ID);
            updatedValue.YETENEK = y.YETENEK;
            updatedValue.YUZDE = y.YUZDE;
            updatedValue.DURUM = y.DURUM;
            yetenek.TUpdate(updatedValue);
            return RedirectToAction("Yetenek");
        }
        #endregion

        #endregion
    }
}