namespace Vidly_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_IsSubscribedToNewsLetter_Property : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "IsSubscribedToNewsLetter", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "IsSubscribedToNewsLetter");
        }
    }
}
