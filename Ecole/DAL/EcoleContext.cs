using Ecole.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Ecole.DAL
{
    public class EcoleContext : DbContext
    {
        public EcoleContext():base("EcoleContext")
        {

        }

        public DbSet<Parent> Parents { get; set; }
        public DbSet<Eleve> Eleves { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Periode> Periodes { get; set; }
        public DbSet<Matiere> Matieres { get; set; }
        public DbSet<Enseignant> Enseignants { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Annee> Annees { get; set; }
        public DbSet<Departement> Departements { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}