namespace Semana10.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V102 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "CourseType_CourseTypeId", c => c.Int());
            CreateIndex("dbo.Courses", "CourseType_CourseTypeId");
            AddForeignKey("dbo.Courses", "CourseType_CourseTypeId", "dbo.CourseTypes", "CourseTypeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "CourseType_CourseTypeId", "dbo.CourseTypes");
            DropIndex("dbo.Courses", new[] { "CourseType_CourseTypeId" });
            DropColumn("dbo.Courses", "CourseType_CourseTypeId");
        }
    }
}
