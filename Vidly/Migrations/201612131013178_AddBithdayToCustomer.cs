namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBithdayToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Birthdate", c => c.DateTime());

            Sql("UPDATE MembershipTypes SET Name = 'Pay as You Go' WHERE Id = 1");
            Sql("UPDATE MembershipTypes SET Name = 'Monthly' WHERE Id = 2");
            Sql("UPDATE MembershipTypes SET Name = 'Quarterly' WHERE Id = 3");
            Sql("UPDATE MembershipTypes SET Name = 'Annual' WHERE Id = 4");

            Sql("UPDATE Customers SET Birthdate = '2016-01-01' WHERE Id = 9");
            Sql("UPDATE Customers SET Birthdate = '1995-01-01' WHERE Id = 10");
        }

        public override void Down()
        {
            DropColumn("dbo.Customers", "Birthdate");
        }
    }
}
