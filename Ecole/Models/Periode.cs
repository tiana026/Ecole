using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecole.Models
{
    public class Periode
    {
        public int ID { get; set; }
        public string Moyenne { get; set; }

        //Clés étrangères
        public virtual ICollection<Note> Notes { get; set; }
    }
}