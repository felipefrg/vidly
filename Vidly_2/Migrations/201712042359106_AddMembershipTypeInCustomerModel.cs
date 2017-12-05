namespace Vidly_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipTypeInCustomerModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "MembershiptypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Customers", "MembershiptypeId");
            AddForeignKey("dbo.Customers", "MembershiptypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MembershiptypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershiptypeId" });
            DropColumn("dbo.Customers", "MembershiptypeId");
        }
    }
}
