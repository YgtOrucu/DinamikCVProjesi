using DinamikCVProjesi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;

namespace DinamikCVProjesi.Controllers
{
    public class AnaSayfaController : Controller
    {
        // GET: AnaSayfa
        DB_UdemyAdminPanelliDinamikCVEntities cVEntities = new DB_UdemyAdminPanelliDinamikCVEntities();

        //Hakkımda
        public ActionResult Index()
        {
            var values = cVEntities.TBL_Hakkımda.Where(x=>x.DURUM == true).ToList();
            return View(values);
        }
        public PartialViewResult Deneyim()
        {
            var deneyim = cVEntities.TBL_Deneyimler.Where(x => x.DURUM == true).ToList();
            return PartialView(deneyim);
        }
        public PartialViewResult Egitimler()
        {
            var egıtım = cVEntities.TBL_Egitimler.Where(x => x.DURUM == true).ToList();
            return PartialView(egıtım);
        }
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
        public PartialViewResult Kurslar()
        {
            var values = cVEntities.TBL_Kurslar.Where(x => x.DURUM == true).ToList();
            return PartialView(values);
        }
        public PartialViewResult Yetenekler()
        {
            var yetenek = cVEntities.TBL_Yetenek.Where(x => x.DURUM == true).ToList();
            return PartialView(yetenek);
        }
        public PartialViewResult Hobiler()
        {
            var hobiler = cVEntities.TBL_Hobilerim.Where(x => x.DURUM == true).ToList();
            return PartialView(hobiler);
        }
        public PartialViewResult Sertifikalar()
        {
            var sertifika = cVEntities.TBL_Sertifikalar.Where(x => x.DURUM == true).ToList();
            return PartialView(sertifika);
        }
        public PartialViewResult Beceriler()
        {
            var beceriler = cVEntities.TBL_Beceriler.Where(x => x.DURUM == true).ToList();
            return PartialView(beceriler);
        }
        public PartialViewResult SosyalMedya()
        {
            var sosyalmedya = cVEntities.TBL_SosyalMedya.Where(x => x.DURUM == true).ToList();
            return PartialView(sosyalmedya);
        }


        [HttpGet]
        public PartialViewResult Iletısım()
        {
            return PartialView();
        }

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