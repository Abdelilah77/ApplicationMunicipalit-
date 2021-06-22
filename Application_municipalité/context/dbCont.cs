using Application_municipalité.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Application_municipalité.context
{
    public class dbCont: DbContext
    {

        public virtual DbSet<Demander__naissance> Demander__Naissances { get; set; }
        public virtual DbSet<Demande> Demandes { get; set; }
        public virtual DbSet<declaration_naissance> declaration_naissances { get; set; }
        public virtual DbSet<demande__livret_famille> Demande__Livret_Familles { get; set; }
        public virtual DbSet<conexion> Conexions { get; set; }

    }
}