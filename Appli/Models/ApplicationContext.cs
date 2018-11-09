using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appli.Models
{
    public class ApplicationContext : IdentityDbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<CourseItem> CourseItems { get; set; }

        public DbSet<UserCourse> UserCourses { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            :base(options)
        {
            // Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserCourse>()
           .HasKey(t => new { t.UserId, t.CourseId });

            builder.Entity<UserCourse>()
                .HasOne(sc => sc.User)
                .WithMany(s => s.UserCourses)
                .HasForeignKey(sc => sc.UserId);

            builder.Entity<UserCourse>()
                .HasOne(c => c.Course)
                .WithMany(c => c.UserCourses)
                .HasForeignKey(sc => sc.CourseId);
        }
    }
    
}
