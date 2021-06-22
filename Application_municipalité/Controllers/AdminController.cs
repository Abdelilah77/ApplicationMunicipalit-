using Application_municipalité.context;
using Application_municipalité.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Application_municipalité.Controllers
{
    public class AdminController : Controller
    {
        private dbCont db = new dbCont();
        // GET: Admin

        public ActionResult Emailtest()
        {
         
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Log_Out()
        {
            conexion.sess = "off";
            Session["admin"] = conexion.sess;
            return RedirectToAction("About","Home");
        }
            [HttpPost]
        public ActionResult Index( string email,string pw,string ob)
        {
            var a= db.Conexions.SingleOrDefault(delegate (conexion c)
            {
                return c.Email.Equals(email) && c.Password.Equals(pw);
            }); 
            if (a!=null)
            {
                conexion.sess = "on";
                Session["admin"] = conexion.sess;
                return RedirectToAction("MenuAdmin");
            }
            conexion.i++;
            if (conexion.i < 3) { 
            ViewBag.msgerror = "Mot de passe ou email  incorrect ";
            }
          
            else
            {
                ViewBag.msgerror = "cliquez sur mot de passe oublié pour le recevoir dans votre email ";
                if (ob == "1")
                {
                    var r = db.Conexions.SingleOrDefault(delegate (conexion c)
                    {
                        return c.Email.Equals(email);
                    }) ;
                    if (r==null)
                    {
                        ViewBag.msgerror = " email incorrect ";
                        return View("Index");
                    }
                    try
                    {
                        MailMessage mm = new MailMessage("wavesxdev@gmail.com", r.Email);

                        mm.Subject = "Mot de passe oublié";
                        mm.Body = $"Bonjour Mr: {r.Email} \n votre mot de pass est : {r.Password}";
                        mm.IsBodyHtml = false;

                        SmtpClient sm = new SmtpClient();
                        sm.Host = "smtp.gmail.com";
                        sm.Port = 587;
                        sm.EnableSsl = true;

                        NetworkCredential nc = new NetworkCredential("wavesxdev@gmail.com", "Abdelilah+78");
                        sm.UseDefaultCredentials = false;
                        sm.Credentials = nc;
                        sm.Send(mm);
                    }
                    catch 
                    {

                        ViewBag.msgerror = "email existe pas ";
                    }
                 
                }
            }
            return View("Index");
        }
        public ActionResult MenuAdmin()
        {
           
            if (Session["admin"] == "off")
            {
                return HttpNotFound();
            }
            return View();
        }
        public PartialViewResult dbDemande()
        {
            return PartialView("_dbDemande", db.Demandes.ToList());
        }
        public PartialViewResult dbDemander_naissance()
        {
            return PartialView("_dbDemander_naissance", db.Demander__Naissances.ToList());
        }
        public PartialViewResult dbDeclaration_naissance()
        {
            return PartialView("_dbDeclaration_naissance", db.declaration_naissances.ToList());
        }
        public PartialViewResult dbDemande__livret_famille()
        {
            return PartialView("_dbDemande__livret_famille", db.Demande__Livret_Familles.ToList());
        }
        public PartialViewResult chart()
        {
            return PartialView("_Chart", db.Demandes.ToList());
        }

        public ActionResult Valide(List<string> id, List<string> bo)
        {

            for (int i = 0; i < id.Count; i++)
            {
                Demande dem = new Demande {idD =Convert.ToInt32( id.ElementAt(i)),change=Convert.ToBoolean( bo.ElementAt(i)) };
                using (var db = new dbCont())
                {
                    db.Demandes.Attach(dem);
                    db.Entry(dem).Property(x => x.change).IsModified = true;
                    db.SaveChanges();
                }
            }
          
            return View();
        }
    }
}