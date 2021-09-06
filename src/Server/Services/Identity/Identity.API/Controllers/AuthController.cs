﻿using Identity.API.Application.Objects.DTO;
using Identity.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Identity.API.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : Controller
    {
        public readonly IIdentityService _identityService;
        
        public AuthController(IIdentityService identityService)
        {
            _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
        }

        [HttpPost("new-account")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDTO registerUser)
        {
            if (registerUser == null) return BadRequest();

            var user = new IdentityUser
            {
                UserName = registerUser.Email,
                Email = registerUser.Email,
                EmailConfirmed = true
            };

            var result = await _identityService.RegisterUserAsync(user, registerUser.Password);

            if (!result.Succeeded) return BadRequest(result.Errors);

            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO loginUser)
        {
            if (loginUser == null) return BadRequest();

            var result = await _identityService.SignInAsync(loginUser.Email, loginUser.Password);

            if (!result.Succeeded) return Ok();

            return BadRequest();
        }
    }
}
