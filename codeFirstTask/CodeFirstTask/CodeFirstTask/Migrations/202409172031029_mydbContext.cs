namespace CodeFirstTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mydbContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assignments",
                c => new
                    {
                        AssignmentId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        DueDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AssignmentId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        age = c.Int(),
                        BirthDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.StudentID);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TeacherId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Teachers");
            DropTable("dbo.Students");
            DropTable("dbo.Assignments");
        }
    }
}
