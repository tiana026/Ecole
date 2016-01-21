namespace Ecole.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _002 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Grade", "Annee_ID", "dbo.Annee");
            DropIndex("dbo.Grade", new[] { "Annee_ID" });
            RenameColumn(table: "dbo.Grade", name: "Annee_ID", newName: "AnneeID");
            AddColumn("dbo.Eleve", "GradeID", c => c.Int(nullable: false));
            AlterColumn("dbo.Grade", "AnneeID", c => c.Int(nullable: false));
            CreateIndex("dbo.Grade", "AnneeID");
            CreateIndex("dbo.Eleve", "GradeID");
            AddForeignKey("dbo.Eleve", "GradeID", "dbo.Grade", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Grade", "AnneeID", "dbo.Annee", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Grade", "AnneeID", "dbo.Annee");
            DropForeignKey("dbo.Eleve", "GradeID", "dbo.Grade");
            DropIndex("dbo.Eleve", new[] { "GradeID" });
            DropIndex("dbo.Grade", new[] { "AnneeID" });
            AlterColumn("dbo.Grade", "AnneeID", c => c.Int());
            DropColumn("dbo.Eleve", "GradeID");
            RenameColumn(table: "dbo.Grade", name: "AnneeID", newName: "Annee_ID");
            CreateIndex("dbo.Grade", "Annee_ID");
            AddForeignKey("dbo.Grade", "Annee_ID", "dbo.Annee", "ID");
        }
    }
}
