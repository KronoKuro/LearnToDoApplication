using Appli.Models;
using Appli.Models.Abstract;
using Appli.Models.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Appli.Controllers
{
    [Authorize]
    [Route("api/cabinet/user")]
    public class UserController : Controller
    {
        private IHostingEnvironment _env;
        private IUserRepository _db;
        public UserController(IUserRepository repository, IHostingEnvironment env)
        {
            _db = repository;
            _env = env;
        }

        [HttpGet]
        public IActionResult Cabinet()
        {

            var userId = User.Identity.getUserId<string>();
            User user = _db.Get(userId);
            return Ok(user);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetUser(string id)
        {
            return Ok(_db.Get(id));
        }
    }
}