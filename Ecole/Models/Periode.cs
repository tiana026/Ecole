using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecole.Models
{
    public class Periode
    {
        public int ID { get; set; }
        public string NomPeriode { get; set; }

        //Clés étrangères
        public virtual ICollection<Note> Notes { get; set; }
        public virtual ICollection<Travail> Travails { get; set; }
        public virtual Moyenne Moyenne { get; set; }
        public int MoyenneID { get; set; }
    }
}