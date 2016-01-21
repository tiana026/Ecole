namespace Ecole.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Annee",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AnneeNom = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Grade",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Promotion = c.String(),
                        Annee_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Annee", t => t.Annee_ID)
                .Index(t => t.Annee_ID);
            
            CreateTable(
                "dbo.Departement",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Eleve",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false, maxLength: 30),
                        Postnom = c.String(nullable: false, maxLength: 30),
                        Prenom = c.String(nullable: false, maxLength: 30),
                        DateNaissance = c.DateTime(),
                        LieuNaissance = c.String(maxLength: 30),
                        Adresse = c.String(maxLength: 500),
                        DateInscription = c.DateTime(),
                        Sexe = c.Int(),
                        ParentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Parent", t => t.ParentID, cascadeDelete: true)
                .Index(t => t.ParentID);
            
            CreateTable(
                "dbo.Note",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EleveID = c.Int(nullable: false),
                        PeriodeID = c.Int(nullable: false),
                        MatiereID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Eleve", t => t.EleveID, cascadeDelete: true)
                .ForeignKey("dbo.Matiere", t => t.MatiereID, cascadeDelete: true)
                .ForeignKey("dbo.Periode", t => t.PeriodeID, cascadeDelete: true)
                .Index(t => t.EleveID)
                .Index(t => t.PeriodeID)
                .Index(t => t.MatiereID);
            
            CreateTable(
                "dbo.Matiere",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Intitule = c.String(),
                        EnseignantID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Enseignant", t => t.EnseignantID, cascadeDelete: true)
                .Index(t => t.EnseignantID);
            
            CreateTable(
                "dbo.Enseignant",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false, maxLength: 30),
                        Postnom = c.String(nullable: false, maxLength: 30),
                        Prenom = c.String(nullable: false, maxLength: 30),
                        Sexe = c.Int(),
                        Telephone = c.String(maxLength: 10),
                        Email = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Periode",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Moyenne = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Parent",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false, maxLength: 30),
                        Postnom = c.String(nullable: false, maxLength: 30),
                        Prenom = c.String(nullable: false, maxLength: 30),
                        Sexe = c.Int(),
                        Telephone = c.String(maxLength: 10),
                        Email = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Eleve", "ParentID", "dbo.Parent");
            DropForeignKey("dbo.Note", "PeriodeID", "dbo.Periode");
            DropForeignKey("dbo.Note", "MatiereID", "dbo.Matiere");
            DropForeignKey("dbo.Matiere", "EnseignantID", "dbo.Enseignant");
            DropForeignKey("dbo.Note", "EleveID", "dbo.Eleve");
            DropForeignKey("dbo.Grade", "Annee_ID", "dbo.Annee");
            DropIndex("dbo.Matiere", new[] { "EnseignantID" });
            DropIndex("dbo.Note", new[] { "MatiereID" });
            DropIndex("dbo.Note", new[] { "PeriodeID" });
            DropIndex("dbo.Note", new[] { "EleveID" });
            DropIndex("dbo.Eleve", new[] { "ParentID" });
            DropIndex("dbo.Grade", new[] { "Annee_ID" });
            DropTable("dbo.Parent");
            DropTable("dbo.Periode");
            DropTable("dbo.Enseignant");
            DropTable("dbo.Matiere");
            DropTable("dbo.Note");
            DropTable("dbo.Eleve");
            DropTable("dbo.Departement");
            DropTable("dbo.Grade");
            DropTable("dbo.Annee");
        }
    }
}
