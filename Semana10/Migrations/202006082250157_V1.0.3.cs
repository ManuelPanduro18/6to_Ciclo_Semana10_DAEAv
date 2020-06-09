namespace Semana10.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V103 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "CourseType_CourseTypeId", "dbo.CourseTypes");
            DropIndex("dbo.Courses", new[] { "CourseType_CourseTypeId" });
            DropPrimaryKey("dbo.Courses");
            CreateTable(
                "dbo.Departaments",
                c => new
                    {
                        DepartamentID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Budget = c.Decimal(nullable: false, storeType: "money"),
                        StartDate = c.DateTime(nullable: false),
                        IntructorID = c.Int(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Administrador_ID = c.Int(),
                    })
                .PrimaryKey(t => t.DepartamentID)
                .ForeignKey("dbo.People", t => t.Administrador_ID)
                .Index(t => t.Administrador_ID);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        HireDate = c.DateTime(),
                        EnrollmentDate = c.DateTime(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.OfficeAssigments",
                c => new
                    {
                        InstructorID = c.Int(nullable: false),
                        Location = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.InstructorID)
                .ForeignKey("dbo.People", t => t.InstructorID)
                .Index(t => t.InstructorID);
            
            CreateTable(
                "dbo.Enrollments",
                c => new
                    {
                        EnrollmentID = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        StudentID = c.Int(nullable: false),
                        Grade = c.Int(),
                    })
                .PrimaryKey(t => t.EnrollmentID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.CourseID)
                .Index(t => t.StudentID);
            
            CreateTable(
                "dbo.InstructorCourses",
                c => new
                    {
                        Instructor_ID = c.Int(nullable: false),
                        Course_CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Instructor_ID, t.Course_CourseID })
                .ForeignKey("dbo.People", t => t.Instructor_ID, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_CourseID, cascadeDelete: true)
                .Index(t => t.Instructor_ID)
                .Index(t => t.Course_CourseID);
            
            AddColumn("dbo.Courses", "Credits", c => c.Int(nullable: false));
            AddColumn("dbo.Courses", "DepartamentID", c => c.Int(nullable: false));
            AlterColumn("dbo.Courses", "CourseID", c => c.Int(nullable: false));
            AlterColumn("dbo.Courses", "Title", c => c.String(maxLength: 50));
            AddPrimaryKey("dbo.Courses", "CourseID");
            CreateIndex("dbo.Courses", "DepartamentID");
            AddForeignKey("dbo.Courses", "DepartamentID", "dbo.Departaments", "DepartamentID", cascadeDelete: true);
            DropColumn("dbo.Courses", "CourseType_CourseTypeId");
            DropTable("dbo.CourseTypes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CourseTypes",
                c => new
                    {
                        CourseTypeId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.CourseTypeId);
            
            AddColumn("dbo.Courses", "CourseType_CourseTypeId", c => c.Int());
            DropForeignKey("dbo.Enrollments", "StudentID", "dbo.People");
            DropForeignKey("dbo.Enrollments", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.Courses", "DepartamentID", "dbo.Departaments");
            DropForeignKey("dbo.Departaments", "Administrador_ID", "dbo.People");
            DropForeignKey("dbo.OfficeAssigments", "InstructorID", "dbo.People");
            DropForeignKey("dbo.InstructorCourses", "Course_CourseID", "dbo.Courses");
            DropForeignKey("dbo.InstructorCourses", "Instructor_ID", "dbo.People");
            DropIndex("dbo.InstructorCourses", new[] { "Course_CourseID" });
            DropIndex("dbo.InstructorCourses", new[] { "Instructor_ID" });
            DropIndex("dbo.Enrollments", new[] { "StudentID" });
            DropIndex("dbo.Enrollments", new[] { "CourseID" });
            DropIndex("dbo.OfficeAssigments", new[] { "InstructorID" });
            DropIndex("dbo.Departaments", new[] { "Administrador_ID" });
            DropIndex("dbo.Courses", new[] { "DepartamentID" });
            DropPrimaryKey("dbo.Courses");
            AlterColumn("dbo.Courses", "Title", c => c.String());
            AlterColumn("dbo.Courses", "CourseID", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Courses", "DepartamentID");
            DropColumn("dbo.Courses", "Credits");
            DropTable("dbo.InstructorCourses");
            DropTable("dbo.Enrollments");
            DropTable("dbo.OfficeAssigments");
            DropTable("dbo.People");
            DropTable("dbo.Departaments");
            AddPrimaryKey("dbo.Courses", "CourseID");
            CreateIndex("dbo.Courses", "CourseType_CourseTypeId");
            AddForeignKey("dbo.Courses", "CourseType_CourseTypeId", "dbo.CourseTypes", "CourseTypeId");
        }
    }
}
