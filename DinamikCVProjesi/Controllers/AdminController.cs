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
            return View();
        }
        #endregion
    }
}