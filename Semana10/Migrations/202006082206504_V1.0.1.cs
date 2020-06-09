namespace Semana10.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V101 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseTypes",
                c => new
                    {
                        CourseTypeId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.CourseTypeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CourseTypes");
        }
    }
}
