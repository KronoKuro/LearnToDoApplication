using Appli.Models.Abstract;
using Appli.Models.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Appli.Models.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private ApplicationContext db;
        
        public CourseRepository(ApplicationContext context)
        {
            this.db = context;
        }

        

        public void Create(Course item)
        {
            db.Courses.Add(item);
            db.SaveChanges();
        }

        public void Delete(string id)
        {
            Course item = db.Courses.FirstOrDefault(g => g.Id == id);
            if (item != null)
            {
                db.Courses.Remove(item);
                db.SaveChanges();
            }
        }

        public Course Get(string id)
        {
            return db.Courses.FirstOrDefault(g => g.Id == id);
        }

        public IEnumerable<Course> GetAll()
        {
            return db.Courses;
        }

        public IEnumerable<Course> GetUserCourses(string userId)
        {
            
            var userCourses = db.Users.Include(x => x.UserCourses).ThenInclude(c => c.Course).FirstOrDefault(x => x.Id == userId);
            /* var courses = db.Users.Include(x => x.UserCourses)
                 .ThenInclude(c => c.Course)
                 .Select(x => x.UserCourses
                 .Select(c => c.Course));*/
            List<Course> courses = userCourses.UserCourses.Select(x => x.Course).ToList();
            return courses.ToList();
        }

        public void Update(Course item)
        {
            var local = db.Set<Course>().FirstOrDefault(entry => entry.Id.Equals(item.Id));
            if (local != null)
            {
                db.Entry(local).State = EntityState.Detached;
            }
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
