namespace SmartTraining.Data.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class course_Optional_columns : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Course", "InstructorId", "dbo.Instructor");
            DropIndex("dbo.Course", new[] { "InstructorId" });
            AlterColumn("dbo.Course", "InstructorId", c => c.Int());
            CreateIndex("dbo.Course", "InstructorId");
            AddForeignKey("dbo.Course", "InstructorId", "dbo.Instructor", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Course", "InstructorId", "dbo.Instructor");
            DropIndex("dbo.Course", new[] { "InstructorId" });
            AlterColumn("dbo.Course", "InstructorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Course", "InstructorId");
            AddForeignKey("dbo.Course", "InstructorId", "dbo.Instructor", "Id", cascadeDelete: true);
        }
    }
}
