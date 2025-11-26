using DinamikCVProjesi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;

namespace DinamikCVProjesi.Controllers
{ 
    [AllowAnonymous]
    public class AnaSayfaController : Controller
    {
        // GET: AnaSayfa
        DB_UdemyAdminPanelliDinamikCVEntities cVEntities = new DB_UdemyAdminPanelliDinamikCVEntities();
        LoginController login = new LoginController();
        

        //Hakkımda
        public ActionResult Index()
        {
            var values = cVEntities.TBL_Hakkımda.Where(x=>x.DURUM == true).ToList();
            return View(values);
        }
        [ChildActionOnly]
        public PartialViewResult Deneyim()
        {
            var deneyim = cVEntities.TBL_Deneyimler.Where(x => x.DURUM == true).ToList();
            return PartialView(deneyim);
        }
        [ChildActionOnly]
        public PartialViewResult Egitimler()
        {
            var egıtım = cVEntities.TBL_Egitimler.Where(x => x.DURUM == true).ToList();
            return PartialView(egıtım);
        }
        [ChildActionOnly]
        public PartialViewResult Diller()
        {
            var values = cVEntities.TBL_Diller.Where(y=>y.DURUM == true).Select(x => new DillerViewModel
            {
                AD = x.AD,
                OKUMA = x.TBL_DilBilgisi.ACIKLAMA,
                YAZMA = x.TBL_DilBilgisi1.ACIKLAMA,
                KONUSMA = x.TBL_DilBilgisi2.ACIKLAMA,
                DİNLEME = x.TBL_DilBilgisi3.ACIKLAMA
            }).ToList();
            return PartialView(values);
        }
        [ChildActionOnly]
        public PartialViewResult Kurslar()
        {
            var values = cVEntities.TBL_Kurslar.Where(x => x.DURUM == true).ToList();
            return PartialView(values);
        }
        [ChildActionOnly]
        public PartialViewResult Yetenekler()
        {
            var yetenek = cVEntities.TBL_Yetenek.Where(x => x.DURUM == true).ToList();
            return PartialView(yetenek);
        }
        [ChildActionOnly]
        public PartialViewResult Hobiler()
        {
            var hobiler = cVEntities.TBL_Hobilerim.Where(x => x.DURUM == true).ToList();
            return PartialView(hobiler);
        }
        [ChildActionOnly]
        public PartialViewResult Sertifikalar()
        {
            var sertifika = cVEntities.TBL_Sertifikalar.Where(x => x.DURUM == true).ToList();
            return PartialView(sertifika);
        }
        [ChildActionOnly]
        public PartialViewResult Beceriler()
        {
            var beceriler = cVEntities.TBL_Beceriler.Where(x => x.DURUM == true).ToList();
            return PartialView(beceriler);
        }
        [ChildActionOnly]
        public PartialViewResult SosyalMedya()
        {
            var sosyalmedya = cVEntities.TBL_SosyalMedya.Where(x => x.DURUM == true).ToList();
            return PartialView(sosyalmedya);
        }
        [ChildActionOnly]
        public ActionResult AdminPaneliButonu()
        {
            var kullaniciAd = Session["KULLANICIAD"]?.ToString();

            if (kullaniciAd != null)
            {
                return PartialView();
            }

            return new EmptyResult();
        }
        [ChildActionOnly]
        [HttpGet]
        public PartialViewResult Iletısım()
        {
            return PartialView();
        }
        [ChildActionOnly]
        [HttpPost]
        public PartialViewResult Iletısım(TBL_İletisim i)
        {
            i.TARİH = DateTime.Parse(DateTime.Now.ToShortDateString());
            cVEntities.TBL_İletisim.Add(i);
            cVEntities.SaveChanges();
            return PartialView();
        }
    }
}