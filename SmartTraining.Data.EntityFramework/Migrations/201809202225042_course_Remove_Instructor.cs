namespace SmartTraining.Data.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class course_Remove_Instructor : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Course", "InstructorId", "dbo.Instructor");
            DropIndex("dbo.Course", new[] { "InstructorId" });
            DropColumn("dbo.Course", "InstructorId");
            DropTable("dbo.Instructor");
        }
        
        public override void Down()
        {
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
            
            AddColumn("dbo.Course", "InstructorId", c => c.Int());
            CreateIndex("dbo.Course", "InstructorId");
            AddForeignKey("dbo.Course", "InstructorId", "dbo.Instructor", "Id");
        }
    }
}
