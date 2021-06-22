using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Application_municipalité.Models
{
    [Table("Demander__naissance")]
    public class Demander__naissance:Demande
    {

    
        public int naissanceEx { get; set; }
        public int intégrale { get; set; }
        public bool Mariage { get; set; }
        public string Prenom_mere { get; set; }
        public string Nom_mère { get; set; }
        public DateTime? Date_naissance { get; set; }

        public int Numéro_acte { get; set; }
        public int Année_établissement { get; set; }
        


        public Demander__naissance() { }
        public Demander__naissance(string nom, string prenom, bool Sexe, int naissanceEx, int intégrale,
                                    bool Mariage, string Prenom_mere,
                                    string Nom_mère, DateTime Date_naissance,
                                    int Numéro_acte, int Année_établissement)
                                    : base(nom, prenom,  Sexe)
        {
            this.naissanceEx = naissanceEx;
            this.intégrale = intégrale;
            this.Mariage = Mariage;
            this.Prenom_mere = Prenom_mere;
            this.Nom_mère = Nom_mère;
            this.Date_naissance = Date_naissance;
            this.Numéro_acte = Numéro_acte;
            this.Année_établissement = Année_établissement;
        }

        public  void AjouterDemende()
        {
            
        }

     
    }
}