namespace Ecole.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _006_AjoutMoyenne : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Moyenne",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        CoteMoyenne = c.Single(nullable: false),
                        PeriodeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Periode", t => t.ID)
                .Index(t => t.ID);
            
            AddColumn("dbo.Periode", "MoyenneID", c => c.Int(nullable: false));
            AddColumn("dbo.Travail", "CoteTravail", c => c.Single(nullable: false));
            AddColumn("dbo.Travail", "MoyenneID", c => c.Int(nullable: false));
            CreateIndex("dbo.Travail", "MoyenneID");
            AddForeignKey("dbo.Travail", "MoyenneID", "dbo.Moyenne", "ID", cascadeDelete: true);
            DropColumn("dbo.Periode", "Moyenne");
            DropColumn("dbo.Travail", "Cote");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Travail", "Cote", c => c.Single(nullable: false));
            AddColumn("dbo.Periode", "Moyenne", c => c.Single(nullable: false));
            DropForeignKey("dbo.Travail", "MoyenneID", "dbo.Moyenne");
            DropForeignKey("dbo.Moyenne", "ID", "dbo.Periode");
            DropIndex("dbo.Travail", new[] { "MoyenneID" });
            DropIndex("dbo.Moyenne", new[] { "ID" });
            DropColumn("dbo.Travail", "MoyenneID");
            DropColumn("dbo.Travail", "CoteTravail");
            DropColumn("dbo.Periode", "MoyenneID");
            DropTable("dbo.Moyenne");
        }
    }
}
