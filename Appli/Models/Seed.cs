using Appli.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Appli.Models
{
    public class Seed
    {
        public static void Initialize(ApplicationContext context)
        {
            if (!context.Courses.Any())
            {
                context.Courses.AddRange(
                    new Course
                    {
                        Id = Guid.NewGuid().ToString(),
                        Title = "C# Course",
                        Description = "Do you learn C#?",
                    }
                );
            };
            context.SaveChanges();
            if (!context.CourseItems.Any())
            {
                var course = context.Courses.FirstOrDefault(x => x.Description != null);
                context.CourseItems.AddRange(
                    new CourseItem
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Sintax C#",
                        IsCompleted = false,
                        CourseId = course.Id == null ? course.Id : null 
                    }
                );
            }

          

            if (!context.Roles.Any())
            {
                context.Roles.AddRange(
                    new Role
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "User",
                    }
                );
                context.Roles.AddRange(
                    new Role
                    {
                        Id = "b44c9bd1-ad78-447a-b498-97cd2e86e7e3",
                        Name = "Admin",
                    }
                );
            }


            context.SaveChanges();

            if (!context.Users.Any())
            {
                var user = context.Roles.FirstOrDefault(u => u.Name == "User");
                var admin = context.Roles.FirstOrDefault(a => a.Name == "Admin");
                context.Users.AddRange(
                    new User
                    {
                        Id = Guid.NewGuid().ToString(),
                        Login = "User",
                        FirstName = "UserFirstName",
                        LastName = "UserLastName",
                        Password = "7Rbtv04wQNxgyhu4OpD7MQ==",
                        RoleId = string.IsNullOrEmpty(user.Id) ? null : user.Id
                    }
                );
                context.Users.AddRange(
                    new User
                    {
                        Id = Guid.NewGuid().ToString(),
                        Login = "Admin",
                        FirstName = "AdminFirstName",
                        LastName = "AdminLastName",
                        Password = "o6dRJbVxag8bW3NhXG5K7g==",
                        RoleId = string.IsNullOrEmpty(admin.Id) ? null : admin.Id
                    }
                );
            }
            context.SaveChanges();
            if (!context.UserCourses.Any())
            {
                var course = context.Courses.FirstOrDefault(x => x.Description == "Do you learn C#?");
                var user = context.Users.FirstOrDefault(x => x.Login == "User");
                context.UserCourses.AddRange(
                    new UserCourse
                    {
                        Id = Guid.NewGuid().ToString(),
                        UserId = user.Id,
                        CourseId = course.Id,
                    }
                );
            }
            context.SaveChanges();
        }
    }
}
