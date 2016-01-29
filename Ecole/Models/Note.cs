using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecole.Models
{
    public class Note
    {
        public int ID { get; set; }


        //Clés étrangères
        public virtual Eleve Eleve { get; set; }
        public int EleveID { get; set; }
        public virtual Matiere Matiere { get; set; }
        public int MatiereID { get; set; }
        public virtual ICollection<Periode> Periodes { get; set; }
        public virtual ICollection<Travail> Travails { get; set; }
    }
}