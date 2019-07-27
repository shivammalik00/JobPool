namespace JobPool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTypeOfJob : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PostedJobs", "TypeOfJob_ID", "dbo.TypeOfJobs");
            DropIndex("dbo.PostedJobs", new[] { "TypeOfJob_ID" });
            AlterColumn("dbo.PostedJobs", "TypeOfJob_ID", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PostedJobs", "TypeOfJob_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.PostedJobs", "TypeOfJob_ID");
            AddForeignKey("dbo.PostedJobs", "TypeOfJob_ID", "dbo.TypeOfJobs", "Id", cascadeDelete: true);
        }
    }
}
