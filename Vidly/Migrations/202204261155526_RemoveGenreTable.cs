namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveGenreTable : DbMigration
    {
        public override void Up()
        {
            Sql("DROP TABLE Genres");
        }
        
        public override void Down()
        {
        }
    }
}
