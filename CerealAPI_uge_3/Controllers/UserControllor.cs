using CerealAPI_uge_3.Interface;
using CerealAPI_uge_3.Models;
using CerealAPI_uge_3.Repostitory;
using Microsoft.AspNetCore.Mvc;

namespace CerealAPI_uge_3.Controllers
{
    [Route("api/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class UserControllor: Controller
    {
        private readonly IUserRepository userRepository;

        public UserControllor(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        public IActionResult GetCereal()
        {
            var Users = userRepository.GetUsers();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                return Ok(Users);
            }
        }
    }
}
