namespace Vidly_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Seed_GenreTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO GENREMODELS VALUES('Action')");
            Sql("INSERT INTO GENREMODELS VALUES('Adventure')");
            Sql("INSERT INTO GENREMODELS VALUES('Comedy')");
            Sql("INSERT INTO GENREMODELS VALUES('Crime')");
            Sql("INSERT INTO GENREMODELS VALUES('Drama')");
            Sql("INSERT INTO GENREMODELS VALUES('Thriller')");
        }
        
        public override void Down()
        {
            
        }
    }
}
