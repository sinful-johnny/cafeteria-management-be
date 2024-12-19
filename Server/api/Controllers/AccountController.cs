using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using api.Interfaces;
using api.Identity;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITokenService _tokenService;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Message = "Invalid login request." });

            // Find the user by username
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null)
                return Unauthorized(new { Message = "Invalid username or password." });

            // Check the password
            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (!result.Succeeded)
                return Unauthorized(new { Message = "Invalid username or password." });

            // Get user roles
            var roles = await _userManager.GetRolesAsync(user);

            // Generate the token
            var token = await _tokenService.CreateToken(user.UserName, roles);

            // Return the token to the frontend
            return Ok(new { Token = token });
        }
    }

    // Login request model
    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}