//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Linq;
//using System.Web;

//namespace Ecole.Models
//{
//    public class Moyenne
//    {
//        [Key]
//        [ForeignKey("Periode")]
//        public int ID { get; set; }
//        public float CoteMoyenne { get; set; }


//        //Clés étrangères
//        public virtual Periode Periode { get; set; }
//        public int PeriodeID { get; set; }
//        public virtual ICollection<Travail> Travails { get; set; }
//    }
//}