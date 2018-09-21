namespace SmartTraining.Data.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Hours = c.Int(nullable: false),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(nullable: false),
                        InstructorId = c.Int(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        ModifiedBy = c.String(nullable: false),
                        ModifiedAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Instructor", t => t.InstructorId, cascadeDelete: true)
                .Index(t => t.InstructorId);
            
            CreateTable(
                "dbo.CourseStudents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Course", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Student", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        ModifiedBy = c.String(nullable: false),
                        ModifiedAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Instructor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Title = c.String(),
                        BirthDate = c.DateTime(),
                        CreatedBy = c.String(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        ModifiedBy = c.String(nullable: false),
                        ModifiedAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Course", "InstructorId", "dbo.Instructor");
            DropForeignKey("dbo.CourseStudents", "StudentId", "dbo.Student");
            DropForeignKey("dbo.CourseStudents", "CourseId", "dbo.Course");
            DropIndex("dbo.CourseStudents", new[] { "StudentId" });
            DropIndex("dbo.CourseStudents", new[] { "CourseId" });
            DropIndex("dbo.Course", new[] { "InstructorId" });
            DropTable("dbo.Instructor");
            DropTable("dbo.Student");
            DropTable("dbo.CourseStudents");
            DropTable("dbo.Course");
        }
    }
}
