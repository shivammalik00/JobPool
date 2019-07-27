namespace JobPool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foriegnkey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PostedJobs", "State_Id1", "dbo.States");
            DropForeignKey("dbo.PostedJobs", "TypeOfJob_Id", "dbo.TypeOfJobs");
            DropIndex("dbo.PostedJobs", new[] { "State_Id1" });
            DropIndex("dbo.PostedJobs", new[] { "TypeOfJob_Id" });
            DropColumn("dbo.PostedJobs", "State_Id");
            RenameColumn(table: "dbo.PostedJobs", name: "State_Id1", newName: "State_Id");
            DropPrimaryKey("dbo.PostedJobs");
            AlterColumn("dbo.PostedJobs", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.PostedJobs", "State_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.PostedJobs", "TypeOfJob_ID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.PostedJobs", "Id");
            CreateIndex("dbo.PostedJobs", "TypeOfJob_ID");
            CreateIndex("dbo.PostedJobs", "State_Id");
            AddForeignKey("dbo.PostedJobs", "State_Id", "dbo.States", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PostedJobs", "TypeOfJob_ID", "dbo.TypeOfJobs", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PostedJobs", "TypeOfJob_ID", "dbo.TypeOfJobs");
            DropForeignKey("dbo.PostedJobs", "State_Id", "dbo.States");
            DropIndex("dbo.PostedJobs", new[] { "State_Id" });
            DropIndex("dbo.PostedJobs", new[] { "TypeOfJob_ID" });
            DropPrimaryKey("dbo.PostedJobs");
            AlterColumn("dbo.PostedJobs", "TypeOfJob_ID", c => c.Int());
            AlterColumn("dbo.PostedJobs", "State_Id", c => c.Int());
            AlterColumn("dbo.PostedJobs", "Id", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.PostedJobs", "Id");
            RenameColumn(table: "dbo.PostedJobs", name: "State_Id", newName: "State_Id1");
            AddColumn("dbo.PostedJobs", "State_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.PostedJobs", "TypeOfJob_Id");
            CreateIndex("dbo.PostedJobs", "State_Id1");
            AddForeignKey("dbo.PostedJobs", "TypeOfJob_Id", "dbo.TypeOfJobs", "Id");
            AddForeignKey("dbo.PostedJobs", "State_Id1", "dbo.States", "Id");
        }
    }
}
