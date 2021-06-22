using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Application_municipalité.Models
{
    [Table("declaration_naissance")]
    public class declaration_naissance:Demande
    {
        public string Prenom_mere { get; set; }
        public string Nom_mère { get; set; }
        public string Prenom_pere { get; set; }
        public DateTime? Date_naissance { get; set; }
        public int HeurN { get; set; }
        public int MinN { get; set; }
        public string typeN { get; set; }
        public string Communaute { get; set; }

        public string NomberB { get; set; }

        public string Territoire { get; set; }

    }
}