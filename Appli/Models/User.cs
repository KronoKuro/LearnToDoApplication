using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appli.Models
{
    public class User: IdentityUser
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public byte[] ImageData { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ImageMimeType { get; set; }
        
        public string RoleId { get; set; }

        public virtual Role Role { get; set; }
        
        public virtual List<UserCourse> UserCourses { get; set; }

        public User()
        {
            UserCourses = new List<UserCourse>();
        }
    }
}
