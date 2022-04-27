using Microsoft.EntityFrameworkCore;
using StudentCounselling.Entities;
using System.Linq;
using System.Reflection;

namespace StudentCounselling.Context
{
    public class StudentCouncellingDbContext: DbContext
    {

        public StudentCouncellingDbContext(DbContextOptions<StudentCouncellingDbContext> opt) : base(opt)
        {
        }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //    builder.Entity<User>().HasIndex(h => h.Department).IsUnique(true);
        //    builder.Entity<User>().HasIndex(h => h.Role).IsUnique(true);
        //    builder.Entity<User>().HasIndex(h => h.Address).IsUnique(true);
        //}
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}
