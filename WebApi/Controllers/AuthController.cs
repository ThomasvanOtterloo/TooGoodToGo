using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Text;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [HttpPost("api/signin")]
        public async Task<IActionResult> SignIn([FromBody] AuthCredentials authCredentials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByNameAsync(authCredentials.Email);
            if (user == null)
            {
                return BadRequest(new { StatusCode = (int)HttpStatusCode.BadRequest, Message = "Email or password is not correct, please try again." });
            }

            var result = await _signInManager.PasswordSignInAsync(user, authCredentials.Password, false, false);
            if (!result.Succeeded)
            {
                return BadRequest(new { StatusCode = (int)HttpStatusCode.BadRequest, Message = "Email or password is not correct, please try again." });
            }

            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = (await _signInManager.CreateUserPrincipalAsync(user)).Identities.First(),
                Expires = DateTime.Now.AddMinutes(int.Parse(_configuration["BearerTokens:ExpiryMinutes"])),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["BearerTokens:Key"])), SecurityAlgorithms.HmacSha256Signature)
            };

            var handler = new JwtSecurityTokenHandler();
            var securityToken = new JwtSecurityTokenHandler().CreateToken(securityTokenDescriptor);

            return Ok(new { StatusCode = (int)HttpStatusCode.OK, Message = "Logged in successfully.", Token = handler.WriteToken(securityToken) });
        }

        [HttpPost("api/signout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok(new { StatusCode = (int)HttpStatusCode.OK, Message = "Logged out successfully" });
        }
    }

}
