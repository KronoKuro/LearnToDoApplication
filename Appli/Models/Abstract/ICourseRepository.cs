using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appli.Models.Abstract
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetAll();
        IEnumerable<UserCourseModel> GetUserCourses(string id);
        Course Get(string id);
        void Create(Course item);
        void Update(Course item);
        void Delete(string id);
    }
}
