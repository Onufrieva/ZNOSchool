namespace ZNOSchool.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Subjects",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    ApplicationUser_Id = c.String(maxLength: 128),
                })
                .PrimaryKey(t => t.Id)
            .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
            .Index(t => t.ApplicationUser_Id);
            AddColumn("dbo.AspNetUsers", "Age", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subjects", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Subjects", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.AspNetUsers", "Age");
            DropTable("dbo.Subjects");
        }
    }
}
