namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeColumnsOfCustomerWithFluentAPI : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Customers", name: "MembershipTypeId", newName: "MembershipId");
            RenameIndex(table: "dbo.Customers", name: "IX_MembershipTypeId", newName: "IX_MembershipId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Customers", name: "IX_MembershipId", newName: "IX_MembershipTypeId");
            RenameColumn(table: "dbo.Customers", name: "MembershipId", newName: "MembershipTypeId");
        }
    }
}
