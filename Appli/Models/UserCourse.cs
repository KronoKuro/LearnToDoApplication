using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appli.Models
{
    public class UserCourse
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public string CourseId { get; set; }

        public virtual Course Course { get; set; }

    }
}
