using Microsoft.AspNetCore.Mvc;
using PDI.DTO;
using PDI.Repository.Implentation;
using PDI.Repository.Interface;

namespace PDI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(userSignup signup)
        {
            try
            {
                var user = await _userRepository.RegisterUser(signup);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser(userSignIn signin)
        {
            try
            {
                var user = await _userRepository.LoginUser(signin);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("allusers")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _userRepository.GetAllUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
