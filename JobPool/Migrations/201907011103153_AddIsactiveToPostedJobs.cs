namespace JobPool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsactiveToPostedJobs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PostedJobs", "IsActive", c => c.Boolean(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PostedJobs", "IsActive");
        }
    }
}
