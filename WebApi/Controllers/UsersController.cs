using Microsoft.AspNetCore.Mvc;
using WebApplication1.BusinessLogicLayer.Services;
using System.Collections.Generic;
using WebApplication1.DataAccessLayer.Models;

namespace WebApplication1.WebApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _userService.GetUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUser([FromRoute] Guid id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            try
            {
                var registeredUser = _userService.Register(user);
                return CreatedAtAction(nameof(GetUser), new { id = registeredUser.UserId }, registeredUser);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto loginInfo)
        {
            var authenticatedUser = _userService.Authenticate(loginInfo.Email, loginInfo.Password);
            if (authenticatedUser == null)
                return Unauthorized();
            return Ok(authenticatedUser);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser([FromRoute] Guid id, [FromBody] User updatedUser)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingUser = _userService.GetUserById(id);
            if (existingUser == null)
                return NotFound();

            _userService.UpdateUser(updatedUser);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser([FromRoute] Guid id)
        {
            _userService.DeleteUser(id);
            return NoContent();
        }
    }

    public class LoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}