namespace JobPool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class empty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PostedJobs", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.PostedJobs", "UserId");
            AddForeignKey("dbo.PostedJobs", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PostedJobs", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.PostedJobs", new[] { "UserId" });
            DropColumn("dbo.PostedJobs", "UserId");
        }
    }
}
