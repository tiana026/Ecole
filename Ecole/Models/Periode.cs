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
        public float Moyenne { get; set; }

        //Clés étrangères
        public virtual Note Note { get; set; }
        public int NoteID { get; set; }
        public virtual ICollection<Travail> Travails { get; set; }
    }
}