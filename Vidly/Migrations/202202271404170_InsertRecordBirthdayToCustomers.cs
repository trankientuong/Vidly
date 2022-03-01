namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertRecordBirthdayToCustomers : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthday='11/06/2000' WHERE Name='John Smith'");
        }
        
        public override void Down()
        {
        }
    }
}
