namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name = 'Pay as you go' WHERE DiscountRate = 0 ");
            Sql("UPDATE MembershipTypes SET Name = 'Monthly' WHERE DiscountRate = 10 ");
        }
        
        public override void Down()
        {
        }
    }
}
