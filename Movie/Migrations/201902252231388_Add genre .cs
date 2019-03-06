namespace Movie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addgenre : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Films", "Zanrovi", c => c.String());
            AddColumn("dbo.Genres", "Zanrovi", c => c.String(nullable: false, maxLength: 30));
            DropColumn("dbo.Films", "GenreId");
            DropColumn("dbo.Genres", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Genres", "Name", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.Films", "GenreId", c => c.Int(nullable: false));
            DropColumn("dbo.Genres", "Zanrovi");
            DropColumn("dbo.Films", "Zanrovi");
        }
    }
}
