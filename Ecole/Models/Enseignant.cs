using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ecole.Models
{
    public class Enseignant
    {
        public int ID { get; set; }

        [StringLength(30, ErrorMessage = "Le nom doit comprendre 30 caractères maximum")]
        [Display(Name = "Nom")]
        [Required(ErrorMessage = "Nom requis")]
        public string Nom { get; set; }

        [StringLength(30, ErrorMessage = "Le postnom doit comprendre 30 caractères maximum")]
        [Display(Name = "Postnom")]
        [Required(ErrorMessage = "Postnom requis")]
        public string Postnom { get; set; }

        [StringLength(30, ErrorMessage = "Le prenom doit comprendre 30 caractères maximum")]
        [Display(Name = "Prenom")]
        [Required(ErrorMessage = "Prenom requis")]
        public string Prenom { get; set; }

        [Display(Name = "Nom Complet")]
        public string NomComplet
        {
            get
            {
                return Nom + " " + Postnom + " " + Prenom;
            }
        }

        public Sexe? Sexe { get; set; }

        [StringLength(10, ErrorMessage = "Le numéro doit comprendre 10 caractères maximum")]
        [Display(Name = "Telephone")]
        public string Telephone { get; set; }

        [StringLength(30, ErrorMessage = "L'adresse mail doit comprendre 30 caractères maximum")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }


        //Clés étrangères
        public virtual ICollection<Matiere> Matieres { get; set; }
    }
}