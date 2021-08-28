using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.API.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return Ok(new { value = "Será que funciona o Deploy teste?" });
        }
    }
}
