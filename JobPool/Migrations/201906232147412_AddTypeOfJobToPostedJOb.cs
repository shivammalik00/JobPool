namespace JobPool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTypeOfJobToPostedJOb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PostedJobs", "TypeOfJob_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.PostedJobs", "TypeOfJob_Id");
            AddForeignKey("dbo.PostedJobs", "TypeOfJob_Id", "dbo.TypeOfJobs", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PostedJobs", "TypeOfJob_Id", "dbo.TypeOfJobs");
            DropIndex("dbo.PostedJobs", new[] { "TypeOfJob_Id" });
            DropColumn("dbo.PostedJobs", "TypeOfJob_ID");
        }
    }
}
