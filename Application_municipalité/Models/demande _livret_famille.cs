using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Application_municipalité.Models
{
    [Table("Demander_livret_famille")]
    public class demande__livret_famille:Demande
    {
        public string type_de_demande { get; set; }
        public string Territoire { get; set; }
        public string Communauté { get; set; }
        public string Adresse { get; set; }
        public int Numéro_de_naissance { get; set; }
        public int pour_un_an { get; set; }
        public string situation_familiale { get; set; }
        public string Nlivret_de_famille { get; set; }
        public string nom_du_mari { get; set; }
        public string prenom_du_mari { get; set; }
    }
}