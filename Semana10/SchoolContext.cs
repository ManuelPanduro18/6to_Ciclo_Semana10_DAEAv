using Semana10.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Semana10
{
    public class SchoolContext : DbContext
    {
        public SchoolContext() : base("name=MyContextDB")
        {
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Departament> Departaments{ get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<OfficeAssigment> OfficeAssigments { get; set; }
        public DbSet<Person> People { get; set; }
    }
}