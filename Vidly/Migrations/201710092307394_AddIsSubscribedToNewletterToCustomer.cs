namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsSubscribedToNewletterToCustomer : DbMigration
    {
        public override void Up()
        {
            //var tableArray = new string[] { "AspNetUserRoles", "AspNetUserLogins", "AspNetUsers", "AspNetRoles", "Customers", "Genres", "MembershipTypes", "Movies", "Rentals" };
            //foreach (var table in tableArray)
            //{
            //    Sql($"TRUNCATE TABLE [{table}]");
            //}

            AddColumn("dbo.Customers", "IsSubscribedToNewsletter", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "IsSubscribedToNewsletter");
        }
    }
}
