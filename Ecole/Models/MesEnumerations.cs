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
    public class MesEnumerations
    {        
    }
}