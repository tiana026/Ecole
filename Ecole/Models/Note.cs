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
        public virtual Periode Periode { get; set; }
        public int PeriodeID { get; set; }
        public virtual Matiere Matiere { get; set; }
        public int MatiereID { get; set; }
    }
}