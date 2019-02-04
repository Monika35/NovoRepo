namespace AUD3MOJA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Rating = c.Single(nullable: false),
                        DownloadURL = c.String(),
                        ImgURL = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                        MovieCard = c.String(),
                        Telephone = c.String(),
                        IsSubscribed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClientMovies",
                c => new
                    {
                        Client_Id = c.Int(nullable: false),
                        Movie_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Client_Id, t.Movie_id })
                .ForeignKey("dbo.Clients", t => t.Client_Id, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.Movie_id, cascadeDelete: true)
                .Index(t => t.Client_Id)
                .Index(t => t.Movie_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClientMovies", "Movie_id", "dbo.Movies");
            DropForeignKey("dbo.ClientMovies", "Client_Id", "dbo.Clients");
            DropIndex("dbo.ClientMovies", new[] { "Movie_id" });
            DropIndex("dbo.ClientMovies", new[] { "Client_Id" });
            DropTable("dbo.ClientMovies");
            DropTable("dbo.Clients");
            DropTable("dbo.Movies");
        }
    }
}
