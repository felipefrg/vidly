namespace Vidly_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterMembershipTypeNameTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.MembershipType", newName: "MembershipTypes");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.MembershipTypes", newName: "MembershipType");
        }
    }
}
