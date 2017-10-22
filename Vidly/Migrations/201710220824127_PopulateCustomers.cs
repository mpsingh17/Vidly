namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCustomers : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO CUSTOMERS (Name, IsSubscribedToNewsletter, MembershipTypeId, BirthDate) VALUES ('John Doe', 1, 1, '10/10/1994 12:00:00 AM') ");
            Sql("INSERT INTO CUSTOMERS (Name, IsSubscribedToNewsletter, MembershipTypeId, BirthDate) VALUES ('Steve Smith', 1, 2, '10/10/1994 12:00:00 AM') ");
        }
        
        public override void Down()
        {
        }
    }
}
