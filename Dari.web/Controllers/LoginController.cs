using Dari.Data;
using Dari.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Dari.web.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index() { var Authentifie = HttpContext.User.Identity.IsAuthenticated;
            ViewData["Authentifie"] = Authentifie;
            Client personne = null;
            if (Authentifie)
            { using (var db = new DariContext()) { personne = (from p in db.Clients where p.Nom == HttpContext.User.Identity.Name select p).FirstOrDefault(); } } return View(personne); }


        [HttpPost]
        public ActionResult Index(Client personne, string returnUrl)
        {

            Client perso = null;
            var Authentifie = HttpContext.User.Identity.IsAuthenticated;
            var test = HttpContext.User.Identity.Name;
            
            ViewData["Authentifie"] = Authentifie;
            if (ModelState.IsValid)
            {
                using (var db = new DariContext())
                { perso = (from p in db.Clients where p.Prenom.Equals(personne.Prenom) && p.Password.Equals(personne.Password) select p).FirstOrDefault();
                    if (perso != null) { FormsAuthentication.SetAuthCookie(perso.Nom.ToString(), false);
                        Authentifie = HttpContext.User.Identity.IsAuthenticated;
                        
                        if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl)) return Redirect(returnUrl);
                        return Redirect("/"); } } }
            return View(personne);
            
            
                }
       

        public ActionResult Inscription() { return View(); }
        [HttpPost]
        public ActionResult Inscription(Client client)
        { if (ModelState.IsValid)
            { using (var db = new DariContext()) { db.Clients.Add(client); db.SaveChanges(); }
                FormsAuthentication.SetAuthCookie(client.Nom.ToString(), false); return Redirect("/Login/Index"); }
            return View(client); }

        [Authorize]
        public ActionResult Deconnexion() { FormsAuthentication.SignOut(); return Redirect("/"); }


        




    }


}


