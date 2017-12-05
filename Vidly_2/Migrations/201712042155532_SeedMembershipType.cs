namespace Vidly_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipType VALUES(0,'Pay As You Go',0,0,0)");
            Sql("INSERT INTO MembershipType VALUES(1,'Monthly',30,1,10)");
            Sql("INSERT INTO MembershipType VALUES(2,'Quarterly',90,3,15)");
            Sql("INSERT INTO MembershipType VALUES(3,'Yearly',300,12,20)");
        }
        
        public override void Down()
        {
        }
    }
}
