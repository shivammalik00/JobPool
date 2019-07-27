namespace JobPool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddtabelPostedJibs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PostedJobs",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 500),
                        State_Id = c.Int(nullable: false),
                        Skill = c.String(nullable: false, maxLength: 100),
                        Designation = c.String(nullable: false, maxLength: 100),
                        ValidTill = c.DateTime(nullable: false),
                        City = c.String(nullable: false, maxLength: 20),
                        JobCategory = c.String(maxLength: 50),
                        State_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.States", t => t.State_Id1)
                .Index(t => t.State_Id1);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PostedJobs", "State_Id1", "dbo.States");
            DropIndex("dbo.PostedJobs", new[] { "State_Id1" });
            DropTable("dbo.PostedJobs");
        }
    }
}
