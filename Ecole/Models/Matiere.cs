using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecole.Models
{
    public class Matiere
    {
        public int ID { get; set; }
        public string Intitule { get; set; }
        

        //Clés étrangères
        public virtual ICollection<Note> Notes { get; set; }
        public virtual Enseignant Enseignant { get; set; }
        public int EnseignantID { get; set; }
        //public virtual Grade Grade { get; set; }
        //public int GradeID { get; set; }
    }
}