namespace Vidly_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeNameColumns : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CustomerModels", newName: "Customers");
            RenameTable(name: "dbo.MovieModels", newName: "Movies");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Movies", newName: "MovieModels");
            RenameTable(name: "dbo.Customers", newName: "CustomerModels");
        }
    }
}
