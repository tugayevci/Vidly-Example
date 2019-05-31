namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateMigrationNames : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET MembershipTypeName='Pay As You Go' WHERE ID=1");
            Sql("UPDATE MembershipTypes SET MembershipTypeName='Monthly' WHERE ID=2");
            Sql("UPDATE MembershipTypes SET MembershipTypeName='3-Monhts' WHERE ID=3");
            Sql("UPDATE MembershipTypes SET MembershipTypeName='Annually' WHERE ID=4");

        }

        public override void Down()
        {
        }
    }
}
