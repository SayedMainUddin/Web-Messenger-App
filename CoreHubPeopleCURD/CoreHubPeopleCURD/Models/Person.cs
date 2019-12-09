using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CoreHubPeopleCURD.Models
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
        //public DateTime RecordDate { get; set; } = DateTime.Now;
        //public Guid UniqueID  { get; set; } = Guid.NewGuid();

        //public virtual ICollection<Employee> Employees { get; set; }
    }
    //public class Employee
    //{
    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    public int EmployeeId { get; set; }
    //    [Required]
    //    public string Name { get; set; }
    //    public string Address { get; set; }
    //    public DateTime RecordDate { get; set; } = DateTime.Now;
    //    public Guid UniqueID  { get; set; } = Guid.NewGuid();

    //    public virtual ICollection<Person> Persons { get; set; }
    //}
    public class PersonContext:DbContext
    {
    
        public DbSet<Person> People { get; set; }
        public PersonContext(DbContextOptions<PersonContext> opt):base(opt)
        {

        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Person>().ToTable("People");
        //    modelBuilder.Entity<Person>()
        //        .HasMany(c => c.Employees).WithMany(i => i.EmployeeId)
        //        .Map(t => t.MapLeftKey("CourseID")
        //            .MapRightKey("InstructorID")
        //            .ToTable("CourseInstructor"));
        //    modelBuilder.Entity<Department>().MapToStoredProcedures();

        //    modelBuilder.Entity<Department>()
        //        .Property(p => p.RowVersion).IsConcurrencyToken();
        //}
    }
}
