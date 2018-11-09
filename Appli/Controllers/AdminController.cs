using Appli.Models.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Appli.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/admin/overview")]
    public class AdminController : Controller
    {
        private IHostingEnvironment _env;
        private IUserRepository _userRepository;
        public AdminController(IUserRepository repository, IHostingEnvironment env)
        {
            _userRepository = repository;
            _env = env;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _userRepository.GetAll();
            return Ok(users);
        }
    }
}