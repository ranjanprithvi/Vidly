namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres VALUES (1,'Action')");
            Sql("INSERT INTO Genres VALUES (2,'Thriller')");
            Sql("INSERT INTO Genres VALUES (3,'Comedy')");
            Sql("INSERT INTO Genres VALUES (4,'Romance')");
            Sql("INSERT INTO Genres VALUES (5,'Sci-Fi')");
        }

        public override void Down()
        {
        }
    }
}
