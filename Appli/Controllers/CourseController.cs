using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Appli.Models;
using Appli.Models.Abstract;
using Appli.Models.Infrastructure;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Appli.Controllers
{
    [Authorize]
    [Route("api/cabinet/course")]
    public class CourseController : Controller
    {
        private IHostingEnvironment _env;
        private IUserRepository _userRepository;
        private ICourseRepository _courseRepository;
        public CourseController(
            IUserRepository userRepository,
            ICourseRepository courseRepository,
            IHostingEnvironment env)
        {
            _userRepository = userRepository;
            _courseRepository = courseRepository;
            _env = env;
        }


        [HttpGet]
        public IActionResult Cabinet()
        {
            var userId = User.Identity.GetUserId();
            var courses = _courseRepository.GetUserCourses(userId);
            return Ok(courses);
        }
    }
}