namespace JobPool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SignUpRecruiterMoreDetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "CompanyName", c => c.String(maxLength: 150));
            AddColumn("dbo.AspNetUsers", "CompanyAddress", c => c.String(maxLength: 150));
            AddColumn("dbo.AspNetUsers", "RecruiterName", c => c.String(maxLength: 50));
            AddColumn("dbo.AspNetUsers", "RecruiterDesignation", c => c.String(maxLength: 50));
            AddColumn("dbo.AspNetUsers", "Location", c => c.String(maxLength: 150));
            AddColumn("dbo.AspNetUsers", "MobileNumber", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "HighestQualification", c => c.String(maxLength: 20));
            AlterColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AlterColumn("dbo.AspNetUsers", "LastName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "FirstName", c => c.String(nullable: false));
            DropColumn("dbo.AspNetUsers", "HighestQualification");
            DropColumn("dbo.AspNetUsers", "MobileNumber");
            DropColumn("dbo.AspNetUsers", "Location");
            DropColumn("dbo.AspNetUsers", "RecruiterDesignation");
            DropColumn("dbo.AspNetUsers", "RecruiterName");
            DropColumn("dbo.AspNetUsers", "CompanyAddress");
            DropColumn("dbo.AspNetUsers", "CompanyName");
        }
    }
}
