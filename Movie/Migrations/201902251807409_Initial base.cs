namespace Movie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialbase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Films",
                c => new
                    {
                        FilmId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        GenreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FilmId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        FilmId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GenreId);
            
            CreateTable(
                "dbo.MovieBase",
                c => new
                    {
                        FilmId = c.Int(nullable: false),
                        GenreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FilmId, t.GenreId })
                .ForeignKey("dbo.Films", t => t.FilmId, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.FilmId)
                .Index(t => t.GenreId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieBase", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.MovieBase", "FilmId", "dbo.Films");
            DropIndex("dbo.MovieBase", new[] { "GenreId" });
            DropIndex("dbo.MovieBase", new[] { "FilmId" });
            DropTable("dbo.MovieBase");
            DropTable("dbo.Genres");
            DropTable("dbo.Films");
        }
    }
}
