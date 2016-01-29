using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecole.Models
{
    public class Travail
    {
        public int ID { get; set; }
        public TypeTravail TypeTravail { get; set; }
        public float CoteTravail { get; set; }

        //Clés étrangères
        public virtual Periode Periode { get; set; }
        public int PeriodeID { get; set; }
        public virtual Note Note { get; set; }
        public int NoteID { get; set; }
        public virtual Moyenne Moyenne { get; set; }
        public int MoyenneID { get; set; }
    }
}