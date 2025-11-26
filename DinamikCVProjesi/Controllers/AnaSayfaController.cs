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
            return PartialView();
        }
        public PartialViewResult Kurslar()
        {
            return PartialView();
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