using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appli.Models
{
    public class UserCourseModel
    {
        public string Id { get; set; }

        public string Login { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public byte[] ImageData { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ImageMimeType { get; set; }

        public string RoleId { get; set; }

        public string RoleName { get; set; }

        public string CourseId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
