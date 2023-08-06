using Identity.API.Application.Objects.DTO;
using Identity.API.Application.Settings.Auth;
using Identity.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace Identity.API.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : Controller
    {
        public readonly IIdentityService _identityService;
        private readonly AuthSetting _authSetting;

        public AuthController(IIdentityService identityService, IOptions<AuthSetting> authSetting)
        {
            _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
            _authSetting = authSetting.Value ?? throw new ArgumentNullException(nameof(authSetting));
        }

        [HttpPost("new-account")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDTO registerUser)
        {
            if (registerUser == null) return BadRequest("XX");

            var user = new IdentityUser
            {
                UserName = registerUser.Email,
                Email = registerUser.Email,
                EmailConfirmed = true
            };

            var result = await _identityService.RegisterUserAsync(user, registerUser.Password);

            if (!result.Succeeded) return BadRequest(result.Errors);

            return Ok(_authSetting.GetJwt());
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO loginUser)
        {
            if (loginUser == null) return BadRequest();

            var result = await _identityService.SignInAsync(loginUser.Email, loginUser.Password);

            if (!result.Succeeded) return Ok(_authSetting.GetJwt());

            return BadRequest();
        }
    }
}
