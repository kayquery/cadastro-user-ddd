using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SignIn.Presentation.Models;

namespace SignIn.Controllers.Base
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController : ControllerBase
    {
        [HttpGet("ping")]
        public async Task<IActionResult> Get()
            => Ok(new {Message = "Server is online"});
    }
}