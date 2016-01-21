using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecole.Models
{
    public class Departement
    {
        public int ID { get; set; }
        public string Nom { get; set; }


        //Clés étrangères
        //public virtual ICollection<Grade> Grades { get; set; }
    }
}