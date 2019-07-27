namespace JobPool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddJobAppliedTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobApplieds",
                c => new
                    {
                        PostedJobId = c.Guid(nullable: false),
                        JobApplierId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.PostedJobId, t.JobApplierId })
                .ForeignKey("dbo.AspNetUsers", t => t.JobApplierId, cascadeDelete: true)
                .ForeignKey("dbo.PostedJobs", t => t.PostedJobId)
                .Index(t => t.PostedJobId)
                .Index(t => t.JobApplierId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobApplieds", "PostedJobId", "dbo.PostedJobs");
            DropForeignKey("dbo.JobApplieds", "JobApplierId", "dbo.AspNetUsers");
            DropIndex("dbo.JobApplieds", new[] { "JobApplierId" });
            DropIndex("dbo.JobApplieds", new[] { "PostedJobId" });
            DropTable("dbo.JobApplieds");
        }
    }
}
