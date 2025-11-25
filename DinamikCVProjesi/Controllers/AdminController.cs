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
            if (!ModelState.IsValid) return View(d);
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

        #region EğitimBölümü
        EgıtımRepository egıtım = new EgıtımRepository();
        public ActionResult Egitim()
        {
            var values = egıtım.List();
            return View(values);
        }
        #region EKLE
        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EgitimEkle(TBL_Egitimler e)
        {
            egıtım.TAdd(e);
            return RedirectToAction("Egitim");
        }
        #endregion

        #region SİL
        public ActionResult EgitimSil(int id)
        {
            var deletedıtem = egıtım.TGetID(id);
            egıtım.TDelete(deletedıtem);
            return RedirectToAction("Egitim");
        }
        #endregion

        #region GÜNCELLE
        [HttpGet]
        public ActionResult EgitimGetir(int id)
        {
            var getEgıtım = egıtım.TGetID(id);
            return View("EgitimGetir", getEgıtım);
        }

        [HttpPost]
        public ActionResult EgitimGüncelle(TBL_Egitimler e)
        {
            var updatedıtem = egıtım.TGetID(e.ID);
            updatedıtem.BASLIK = e.BASLIK;
            updatedıtem.ALTBASLIK1 = e.ALTBASLIK1;
            updatedıtem.ALTBASLIK2 = e.ALTBASLIK2;
            updatedıtem.NOT_ORT = e.NOT_ORT;
            updatedıtem.TARİH = e.TARİH;
            updatedıtem.DURUM = e.DURUM;

            egıtım.TUpdate(updatedıtem);
            return RedirectToAction("Egitim");
        }
        #endregion

        #endregion

        #region Beceriler

        BecerilerRepository beceriler = new BecerilerRepository();
        public ActionResult Beceriler()
        {
            var values = beceriler.List();
            return View(values);
        }

        #region EKLE
        [HttpGet]
        public ActionResult BeceriEkle() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult BeceriEkle(TBL_Beceriler b)
        {
            beceriler.TAdd(b);
            return RedirectToAction("Beceriler");
        }
        #endregion

        #region SİL
        public ActionResult BeceriSil(int id)
        {
            var deletedıtem = beceriler.TGetID(id);
            beceriler.TDelete(deletedıtem);
            return RedirectToAction("Beceriler");
        }
        #endregion

        #region GÜNCELLE
        [HttpGet]
        public ActionResult BeceriGetir(int id)
        {
            var getbeceri = beceriler.TGetID(id);
            return View("BeceriGetir", getbeceri);
        }
        [HttpPost]
        public ActionResult BeceriGüncelle(TBL_Beceriler b)
        {
            var updatedBeceri = beceriler.TGetID(b.ID);
            updatedBeceri.BECERİLER = b.BECERİLER;
            updatedBeceri.DURUM = b.DURUM;
            beceriler.TUpdate(updatedBeceri);
            return RedirectToAction("Beceriler");
        }
        #endregion

        #endregion

        #region SertifikaBölümü
        SertifikaRepository sertifika = new SertifikaRepository();
        public ActionResult Sertifikalar()
        {
            var values = sertifika.List();
            return View(values);
        }

        #region EKLE
        [HttpGet]
        public ActionResult SertifikaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SertifikaEkle(TBL_Sertifikalar s)
        {
            sertifika.TAdd(s);
            return RedirectToAction("Sertifikalar");
        }
        #endregion

        #region SerifikaGüncelle
        [HttpGet]
        public ActionResult SertifikaGetir(int id)
        {
            var values = sertifika.TGetID(id);
            return View("SertifikaGetir", values);
        }
        [HttpPost]
        public ActionResult SertifikaGüncelle(TBL_Sertifikalar s)
        {
            var updatedıtem = sertifika.TGetID(s.ID);
            updatedıtem.ACIKLAMA = s.ACIKLAMA;
            updatedıtem.BASLIK = s.BASLIK;
            updatedıtem.TARİH = s.TARİH;
            updatedıtem.DURUM = s.DURUM;
            sertifika.TUpdate(updatedıtem);
            return RedirectToAction("Sertifikalar");
        }
        #endregion

        #endregion

        #region İletişimBölümü
        İletisimRepository iletisim = new İletisimRepository();
        public ActionResult İletisim()
        {
            var values = iletisim.List();
            return View(values);
        }
        #endregion

        #region Hobilerim
        HobilerRepository hobiler = new HobilerRepository();
        public ActionResult Hobilerim()
        {
            var values = hobiler.List();
            return View(values);
        }
        #region EKLE
        [HttpGet]
        public ActionResult HobiEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult HobiEkle(TBL_Hobilerim h)
        {
            h.ACIKLAMA2 = null;
            hobiler.TAdd(h);
            return RedirectToAction("Hobilerim");
        }
        #endregion

        #region SİL
        public ActionResult HobiSil(int id)
        {
            var deletedıtem = hobiler.TGetID(id);
            hobiler.TDelete(deletedıtem);
            return RedirectToAction("Hobilerim");
        }
        #endregion

        #region GÜNCELLE
        [HttpGet]
        public ActionResult HobiGetir(int id)
        {
            var gethobi = hobiler.TGetID(id);
            return View("HobiGetir", gethobi);
        }
        [HttpPost]
        public ActionResult HobiGüncelle(TBL_Hobilerim h)
        {
            var updatedhobi = hobiler.TGetID(h.ID);
            updatedhobi.ACIKLAMA1 = h.ACIKLAMA1;
            updatedhobi.DURUM = h.DURUM;
            hobiler.TUpdate(updatedhobi);
            return RedirectToAction("Hobilerim");
        }
        #endregion

        #endregion
    }
}