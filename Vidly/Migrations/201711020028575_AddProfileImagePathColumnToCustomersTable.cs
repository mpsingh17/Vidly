namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProfileImagePathColumnToCustomersTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "ProfileImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "ProfileImagePath");
        }
    }
}
