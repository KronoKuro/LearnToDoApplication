using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Appli.Models.Abstract;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Appli.Controllers
{
    [Route("api/cabinet/course")]
    public class CourseController : Controller
    {
        private IHostingEnvironment _env;
        private IUserRepository _userRepository;
public CourseController(IUserRepository userrepository, IHostingEnvironment env)
        {
            _userRepository = userrepository;
            _env = env;
        }

/*        [HttpGet]
        public IActionResult Cabinet()
        {

            var userId = User.Identity.getUserId<string>();
            User user = _db.Get(userId);
            return Ok(user);
        }*/

    }
}