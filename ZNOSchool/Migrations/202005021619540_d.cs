namespace ZNOSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class d : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Subjects", "subjectName", c => c.String());
            DropColumn("dbo.Subjects", "name_subject");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Subjects", "name_subject", c => c.String());
            DropColumn("dbo.Subjects", "subjectName");
        }
    }
}
