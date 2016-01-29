namespace Ecole.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _005 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Periode", "NoteID", "dbo.Note");
            DropIndex("dbo.Periode", new[] { "NoteID" });
            CreateTable(
                "dbo.NotePeriode",
                c => new
                    {
                        NoteID = c.Int(nullable: false),
                        PeriodeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.NoteID, t.PeriodeID })
                .ForeignKey("dbo.Note", t => t.NoteID, cascadeDelete: true)
                .ForeignKey("dbo.Periode", t => t.PeriodeID, cascadeDelete: true)
                .Index(t => t.NoteID)
                .Index(t => t.PeriodeID);
            
            AddColumn("dbo.Travail", "NoteID", c => c.Int(nullable: false));
            CreateIndex("dbo.Travail", "NoteID");
            AddForeignKey("dbo.Travail", "NoteID", "dbo.Note", "ID", cascadeDelete: true);
            DropColumn("dbo.Periode", "NoteID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Periode", "NoteID", c => c.Int(nullable: false));
            DropForeignKey("dbo.NotePeriode", "PeriodeID", "dbo.Periode");
            DropForeignKey("dbo.NotePeriode", "NoteID", "dbo.Note");
            DropForeignKey("dbo.Travail", "NoteID", "dbo.Note");
            DropIndex("dbo.NotePeriode", new[] { "PeriodeID" });
            DropIndex("dbo.NotePeriode", new[] { "NoteID" });
            DropIndex("dbo.Travail", new[] { "NoteID" });
            DropColumn("dbo.Travail", "NoteID");
            DropTable("dbo.NotePeriode");
            CreateIndex("dbo.Periode", "NoteID");
            AddForeignKey("dbo.Periode", "NoteID", "dbo.Note", "ID", cascadeDelete: true);
        }
    }
}
