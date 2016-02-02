namespace Ecole.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _007_SuppressionClasseMoyenne : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Moyenne", "ID", "dbo.Periode");
            DropForeignKey("dbo.Travail", "MoyenneID", "dbo.Moyenne");
            DropIndex("dbo.Moyenne", new[] { "ID" });
            DropIndex("dbo.Travail", new[] { "MoyenneID" });
            DropColumn("dbo.Periode", "MoyenneID");
            DropColumn("dbo.Travail", "MoyenneID");
            DropTable("dbo.Moyenne");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Moyenne",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        CoteMoyenne = c.Single(nullable: false),
                        PeriodeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Travail", "MoyenneID", c => c.Int(nullable: false));
            AddColumn("dbo.Periode", "MoyenneID", c => c.Int(nullable: false));
            CreateIndex("dbo.Travail", "MoyenneID");
            CreateIndex("dbo.Moyenne", "ID");
            AddForeignKey("dbo.Travail", "MoyenneID", "dbo.Moyenne", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Moyenne", "ID", "dbo.Periode", "ID");
        }
    }
}
