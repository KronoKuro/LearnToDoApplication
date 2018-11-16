using Appli.Models;
using Appli.Models.Abstract;
using Appli.Models.Infrastructure;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Appli.Controllers
{
    [Authorize(Roles = "User")]
    [Route("api/cabinet/user")]
    public class UserController : Controller
    {
        private IHostingEnvironment _env;
        private IUserRepository _db;
        private ICourseRepository _courseRepository;
        public UserController(IUserRepository repository, ICourseRepository courseRepository, IHostingEnvironment env)
        {
            _db = repository;
            _env = env;
            _courseRepository = courseRepository;
        }
        
        [HttpGet]
        public IActionResult GetUser()
        {
            var userId = User.Identity.GetUserId();
            return Ok(_db.Get(userId));
        }

        
    }
}