namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembershipTypeData : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MEMBERSHIPTYPES SET Name = 'Pay as you go' WHERE ID = 1");
            Sql("UPDATE MEMBERSHIPTYPES SET Name = 'Monthly' WHERE ID = 2");
            Sql("UPDATE MEMBERSHIPTYPES SET Name = 'Quaterly' WHERE ID = 3");
            Sql("UPDATE MEMBERSHIPTYPES SET Name = 'Yearly' WHERE ID = 4");
        }
        
        public override void Down()
        {
        }
    }
}
