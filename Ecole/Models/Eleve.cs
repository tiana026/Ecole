using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ecole.Models
{
    public class Eleve
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

        [Display(Name = "Naissance")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateNaissance { get; set; }

        [StringLength(30, ErrorMessage = "Le lieu de naissance doit comprendre 30 caractères maximum")]
        [Display(Name = "Lieu Naissance")]
        public string LieuNaissance { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(500, ErrorMessage = "L'adresse ne doit pas depasser 500 caracteres")]
        public string Adresse { get; set; }

        [Display(Name = "Inscription")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateInscription { get; set; }

        public Sexe? Sexe { get; set; }


        //Clés étrangères
        public virtual Parent Parent { get; set; }
        public int ParentID { get; set; }
        public virtual Grade Grade { get; set; }
        public int GradeID { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
    }
}