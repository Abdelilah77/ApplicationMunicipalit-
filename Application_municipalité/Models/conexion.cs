using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Application_municipalité.Models
{
    public class conexion
    {
        [Key]
        public int id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public static int i = 0;
        public static string sess = "off";
    }
}