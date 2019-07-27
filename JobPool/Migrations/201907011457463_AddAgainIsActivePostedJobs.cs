namespace JobPool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAgainIsActivePostedJobs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PostedJobs", "IsCanceled", c => c.Boolean(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PostedJobs", "IsCanceled");
        }
    }
}
