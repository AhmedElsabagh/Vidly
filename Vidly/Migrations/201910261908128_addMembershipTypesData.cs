namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMembershipTypesData : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into MembershipTypes Values (1,0,0,0)");
            Sql("Insert into MembershipTypes Values (2,30,1,10)");
            Sql("Insert into MembershipTypes Values (3,90,3,15)");
            Sql("Insert into MembershipTypes Values (4,300,3,15)");
        }
        
        public override void Down()
        {
        }
    }
}
