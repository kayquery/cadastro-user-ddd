using Microsoft.AspNetCore.Mvc;
using SignIn.Application.Interfaces;
using SignIn.Controllers.Base;
using SignIn.Domain.DTO;
using SignIn.Infra.Interfaces;
using SignIn.Presentation.Models;

namespace SignIn.Presentation.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
            => (_userService) = (userService);
        

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserDTO userDTO )
        {
            Result result = await _userService.CreateUser(userDTO);

            if(result.Success)
                return StatusCode(201,result.Data);
                
            return BadRequest(new { result.Message });
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
            => Ok( await _userService.GetUsers());
        

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUser(string userId)
        {
            Result result = await _userService.GetUser(userId);

            if(result.Success)
                return Ok(result.Data);

            if(result.Data == null)
                return NotFound(new { result.Message });

            return BadRequest(new { result.Message });
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> Update(string userId, [FromBody] UserDTO userDTO)
        {   
            Result result = await _userService.UpdateUser(userId, userDTO);

            if(result.Success && result.Data is bool dataBool && dataBool == true )
                return NoContent();

            if(result.Data == null)
                return NotFound();

            return BadRequest(new { result.Message });
        }
    }
}