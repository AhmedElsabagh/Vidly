namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addGenreData : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Genres", "name", c => c.String(nullable: false, maxLength: 255));
            Sql("SET IDENTITY_INSERT Genres ON");
            Sql("Insert into Genres (Id,name) Values(1,'Comedy')");
            Sql("Insert into Genres (Id,name) Values(2,'Action')");
            Sql("Insert into Genres (Id,name) Values(3,'Family')");
            Sql("Insert into Genres (Id,name) Values(4,'Romance')");
            Sql("Insert into Genres (Id,name) Values(5,'Sci-fiction')");
            Sql("SET IDENTITY_INSERT Genres OFF");
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Genres", "name", c => c.String());
        }
    }
}
