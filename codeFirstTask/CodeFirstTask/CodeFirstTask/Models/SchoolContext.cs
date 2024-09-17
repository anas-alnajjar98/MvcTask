using CodeFirstTask.Models;
using System.Collections.Generic;
using System.Data.Entity;

public class SchoolContext : DbContext
{
    public SchoolContext() : base("name=SchoolContext")
    {
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Assignment> Assignments { get; set; }
}
