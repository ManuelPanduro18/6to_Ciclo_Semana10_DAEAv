namespace Semana10.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V105 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OfficeAssigments", "Activo", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OfficeAssigments", "Activo");
        }
    }
}
