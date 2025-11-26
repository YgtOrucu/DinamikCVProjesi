using DinamikCVProjesi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DinamikCVProjesi.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        DB_UdemyAdminPanelliDinamikCVEntities cVEntities = new DB_UdemyAdminPanelliDinamikCVEntities();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TBL_Admin a)
        {
            var values = cVEntities.TBL_Admin.Where(y => y.DURUM == true).FirstOrDefault(x => x.KULLANICIAD == a.KULLANICIAD && x.SIFRE == a.SIFRE);
            if (values != null)
            {
                if(values.DURUM == true)
                {
                    FormsAuthentication.SetAuthCookie(values.KULLANICIAD, false);
                    Session["KULLANICIAD"] = values.KULLANICIAD.ToString();
                    return RedirectToAction("Hakkımda", "Admin");

                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}