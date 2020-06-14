namespace Braille.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kelimeler",
                c => new
                    {
                        KelimeId = c.Int(nullable: false, identity: true),
                        Kelime = c.String(),
                    })
                .PrimaryKey(t => t.KelimeId);
            
            CreateTable(
                "dbo.Skorlar",
                c => new
                    {
                        SkorId = c.Int(nullable: false, identity: true),
                        Telefon = c.String(),
                        Sure = c.Int(nullable: false),
                        KelimeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SkorId)
                .ForeignKey("dbo.Kelimeler", t => t.KelimeId, cascadeDelete: true)
                .Index(t => t.KelimeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Skorlar", "KelimeId", "dbo.Kelimeler");
            DropIndex("dbo.Skorlar", new[] { "KelimeId" });
            DropTable("dbo.Skorlar");
            DropTable("dbo.Kelimeler");
        }
    }
}
