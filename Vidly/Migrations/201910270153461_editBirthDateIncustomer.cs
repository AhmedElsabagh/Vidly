﻿namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editBirthDateIncustomer : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "birthdate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "birthdate", c => c.DateTime(nullable: false));
        }
    }
}
