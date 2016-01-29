using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ecole.Models
{
    public enum Sexe
    {
        [Display(Name = "Masculin")]
        M,
        [Display(Name = "Feminin")]
        F
    }

    public enum TypeTravail
    {
        [Display(Name = "Intérrogation")]
        Interrogation,
        [Display(Name = "Travail Pratique")]
        TP,
        [Display(Name = "Devoir à domicil")]
        Devoir
    }
    public class MesEnumerations
    {        
    }
}