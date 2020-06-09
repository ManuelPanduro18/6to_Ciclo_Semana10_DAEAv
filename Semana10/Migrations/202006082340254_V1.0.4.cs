namespace Semana10.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V104 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "Activo", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "Activo");
        }
    }
}
