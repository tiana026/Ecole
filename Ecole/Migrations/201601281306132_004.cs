namespace Ecole.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _004 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Note", "PeriodeID", "dbo.Periode");
            DropIndex("dbo.Note", new[] { "PeriodeID" });
            CreateTable(
                "dbo.Travail",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TypeTravail = c.Int(nullable: false),
                        Cote = c.Single(nullable: false),
                        PeriodeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Periode", t => t.PeriodeID, cascadeDelete: true)
                .Index(t => t.PeriodeID);
            
            AddColumn("dbo.Periode", "NomPeriode", c => c.String());
            AddColumn("dbo.Periode", "NoteID", c => c.Int(nullable: false));
            AlterColumn("dbo.Periode", "Moyenne", c => c.Single(nullable: false));
            CreateIndex("dbo.Periode", "NoteID");
            AddForeignKey("dbo.Periode", "NoteID", "dbo.Note", "ID", cascadeDelete: true);
            DropColumn("dbo.Note", "PeriodeID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Note", "PeriodeID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Travail", "PeriodeID", "dbo.Periode");
            DropForeignKey("dbo.Periode", "NoteID", "dbo.Note");
            DropIndex("dbo.Travail", new[] { "PeriodeID" });
            DropIndex("dbo.Periode", new[] { "NoteID" });
            AlterColumn("dbo.Periode", "Moyenne", c => c.String());
            DropColumn("dbo.Periode", "NoteID");
            DropColumn("dbo.Periode", "NomPeriode");
            DropTable("dbo.Travail");
            CreateIndex("dbo.Note", "PeriodeID");
            AddForeignKey("dbo.Note", "PeriodeID", "dbo.Periode", "ID", cascadeDelete: true);
        }
    }
}
