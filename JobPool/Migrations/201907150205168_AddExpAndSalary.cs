namespace JobPool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddExpAndSalary : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PostedJobs", "experience", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.PostedJobs", "salary", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PostedJobs", "salary");
            DropColumn("dbo.PostedJobs", "experience");
        }
    }
}
