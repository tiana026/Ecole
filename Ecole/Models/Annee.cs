using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ecole.Models
{
    public class Annee
    {
        public int ID { get; set; }
        [Display(Name = "Année Scolaire")]
        public string AnneeNom { get; set; }

        //Clés étrangères
        public virtual ICollection<Grade> Grades { get; set; }
    }
}