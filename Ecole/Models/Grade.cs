using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecole.Models
{
    public class Grade
    {
        public int ID { get; set; }
        public string Promotion { get; set; }


        //Clés étrangères
        public virtual ICollection<Eleve> Eleves { get; set; }
        public virtual ICollection<Matiere> Matieres { get; set; }
        public virtual Annee Annee { get; set; }
        public int AnneeID { get; set; }
    }
}