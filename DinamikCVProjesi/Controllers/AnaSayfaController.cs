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
            var values = cVEntities.TBL_Hakkımda.ToList();
            return View(values);
        }
        public PartialViewResult Deneyim()
        {
            var deneyim = cVEntities.TBL_Deneyimler.ToList();     
            return PartialView(deneyim);
        }
        public PartialViewResult Egitimler()
        {
            var egıtım = cVEntities.TBL_Egitimler.ToList();
            return PartialView(egıtım);
        }
        public PartialViewResult Yetenekler()
        {
            var yetenek = cVEntities.TBL_Yetenek.ToList();
            return PartialView(yetenek);
        }
        public PartialViewResult Hobiler()
        {
            var hobiler = cVEntities.TBL_Hobilerim.ToList();
            return PartialView(hobiler);
        }
        public PartialViewResult Sertifikalar()
        {
            var sertifika = cVEntities.TBL_Sertifikalar.ToList();
            return PartialView(sertifika);
        }
        public PartialViewResult Beceriler()
        {
            var beceriler = cVEntities.TBL_Beceriler.ToList();
            return PartialView(beceriler);
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