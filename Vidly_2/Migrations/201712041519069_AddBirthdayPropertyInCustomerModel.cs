namespace Vidly_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthdayPropertyInCustomerModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerModels", "Birthday", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerModels", "Birthday");
        }
    }
}
