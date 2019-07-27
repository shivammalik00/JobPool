namespace JobPool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTypeOFJob1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TypeOfJobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameTypeOfJOb = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TypeOfJobs");
        }
    }
}
