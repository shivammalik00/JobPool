namespace JobPool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsactiveToPostedJobs1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PostedJobs", "IsActive");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PostedJobs", "IsActive", c => c.Boolean(nullable: false));
        }
    }
}
