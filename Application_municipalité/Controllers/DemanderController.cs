using Application_municipalité.context;
using Application_municipalité.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Application_municipalité.Controllers
{
    public class DemanderController : Controller
    {
        // GET: Demander
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult Demander_naissance()
        {
            return View(db.declaration_naissances.ToList());
        }
        dbCont db = new dbCont();
        public ActionResult declaration_naissance()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult declaration_naissance([Bind(Include = "nom,prenom,Prenom_mere,Nom_mère,Prenom_mere,Prenom_pere")] declaration_naissance d
            ,string stat,string sexe,int hr,int min,int day , int month ,int year ,string Territoiree, string Communautee,string ty,string cin,string typ)
        {
            System.Diagnostics.Debug.WriteLine(typ);

            string date = $"{Convert.ToString(year)}/{Convert.ToString(month)}/{Convert.ToString(day)}";
            bool a = (sexe.StartsWith("M") ? true : false);
            if (ModelState.IsValid)
            {
                declaration_naissance de = new declaration_naissance
                {
                    nom = d.nom,
                    prenom = d.prenom,
                    Prenom_mere = d.Prenom_mere,
                    Nom_mère = d.Nom_mère,
                    Prenom_pere = d.Prenom_pere,
                    Date_naissance = Convert.ToDateTime(date),
                    HeurN = hr,
                    NomberB = ty,
                    MinN = min,
                    typeN = stat,
                    Sexe = a,
                    Numéro_national_didentité = cin,
                    Territoire = Territoiree,
                    Communaute = Communautee,
                    typedeDemander = "declaration_naissance",
                    change = false

                };
                db.declaration_naissances.Add(de);
                db.SaveChanges();
                return RedirectToAction("About", "Home");
            }

            return View("demander__naissance");
          
        }
   
    [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Demander_naissance(int ExemplairesExtrait =0,int Integrale0=0,int on=0,string prenomAr="",string nomAr=""
       , string prenomMereAr="",string nomMereAr="",string prenomPereAr="",string dateNaissanceNonConnu="",int dateNaissanceJour=0,
        int dateNaissanceMois=0,int dateNaissanceAnnee=0,string sexe="",int numActe=0 ,int anneeActe=0,string cin="",string typ="")
        {
            System.Diagnostics.Debug.WriteLine(typ);
            bool a = (sexe.StartsWith("M") ? true : false);
            DateTime dat = Convert.ToDateTime($"{Convert.ToString(dateNaissanceAnnee)}/{Convert.ToString(dateNaissanceMois)}/{Convert.ToString(dateNaissanceJour)}");
            bool o = on == 1 ? true : false;
            DateTime b = (dateNaissanceNonConnu == "on") ? Convert.ToDateTime("") : dat;
            if (ModelState.IsValid)
            {
                Demander__naissance d = new Demander__naissance
                {
                    naissanceEx = ExemplairesExtrait,
                    intégrale = Integrale0,
                    Mariage = o,
                    prenom = prenomAr,
                    nom = nomAr,
                    Prenom_mere = prenomMereAr,
                    Nom_mère = nomMereAr,
                    Date_naissance = b,
                    Sexe = a,
                    Numéro_acte = numActe,
                    Numéro_national_didentité=cin,
                    Année_établissement = anneeActe,
                    typedeDemander= "Demander_naissance",
                    change = false

                };
                db.Demander__Naissances.Add(d);
                db.SaveChanges();
                return RedirectToAction("About","Home");
            }
            return View("demander__naissance");
        }
        public ActionResult demande_livret_famille()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult demande_livret_famille([Bind(Include = "idD,nom,prenom,Numéro_national_didentité,Sexe,type_de_demande,Territoire,Communauté,Adresse,Numéro_de_naissance,pour_un_an,situation_familiale,Nlivret_de_famille,nom_du_mari,prenom_du_mari")] demande__livret_famille demande__livret_famille,string typ)
        {
            System.Diagnostics.Debug.WriteLine(typ);

            if (ModelState.IsValid)
            {
                demande__livret_famille.typedeDemander = "demande_livret_famille";
                demande__livret_famille.change = false;
                db.Demande__Livret_Familles.Add(demande__livret_famille);
                db.SaveChanges();
                return RedirectToAction("About", "Home");
            }
                return View();
        }
    }
}