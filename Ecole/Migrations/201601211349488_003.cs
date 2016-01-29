namespace Ecole.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _003 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Matiere", "GradeID", c => c.Int(nullable: false));
            CreateIndex("dbo.Matiere", "GradeID");
            //Il faut songer à effacer manuellement les diffentes, car j'ai mis à FALSE le cascadeDelete
            //à cause d'une reference circulaire
            AddForeignKey("dbo.Matiere", "GradeID", "dbo.Grade", "ID", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matiere", "GradeID", "dbo.Grade");
            DropIndex("dbo.Matiere", new[] { "GradeID" });
            DropColumn("dbo.Matiere", "GradeID");
        }
    }
}
