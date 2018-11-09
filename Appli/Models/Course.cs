using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appli.Models
{
    public class Course
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public byte[] ImageData { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ImageMimeType { get; set; }
        
        public virtual ICollection<CourseItem> CourseItems { get; set; }

        public virtual List<UserCourse> UserCourses { get; set; }

        public Course()
        {
            UserCourses = new List<UserCourse>();
        }

    }
}
