using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Application_municipalité.Models
{
    [Table("Demande")]
    public   class  Demande
    {
        [Key]
        public int idD { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string typedeDemander { get; set; }
      
        public string Numéro_national_didentité { get; set; }

        public bool Sexe { get; set; }
        public bool change { get; set; }

        public Demande(string nom, string prenom, bool Sexe)
        {
            this.nom = nom;
            this.prenom = prenom;
       
            this.Sexe = Sexe;
        }
        public Demande() { }
       
       
    }
}