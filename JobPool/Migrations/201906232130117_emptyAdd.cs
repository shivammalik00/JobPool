namespace JobPool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emptyAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PostedJobs", "JobTitle", c => c.String(nullable: false, maxLength: 250));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PostedJobs", "JobTitle");
        }
    }
}
