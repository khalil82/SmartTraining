namespace SmartTraining.Data.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class course_Optional_columns2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Course", "EndDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Course", "EndDate", c => c.DateTime(nullable: false));
        }
    }
}
