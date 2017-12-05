namespace Vidly_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertCustomers : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO CustomerModels VALUES ('Felipe','Rodrigues Gonçalves','1990-11-15')");
            Sql("INSERT INTO CustomerModels VALUES ('Monica Carolina','Cavilha Leonel','1994-02-23')");
        }
        
        public override void Down()
        {
        }
    }
}
