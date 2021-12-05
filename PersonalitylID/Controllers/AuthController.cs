using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PersonalityIdentification.Itrefaces;
using System.Linq;
using PersonalityIdentification.Helpers;
using PersonalityIdentification.DataContext;
using System;

namespace PersonalityIdentification.Controllers
{
    // http://localhost:5000/[controllernmae]/apiName

    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IAuthService authService;
        private readonly IMapper mapper;

        public UserController(IAuthService authService, IMapper mapper)
        {
            this.authService = authService;
            this.mapper = mapper;
        }

        [HttpPost("authuser")]
        public async Task<IActionResult> AuthUser([FromBody] AuthRequestModel authRequestModel)
        {
            var authResponse = await authService.AuthUser(authRequestModel);
            
            return Ok(authResponse);
        }

        [HttpPost("profile")]
        public async Task<IActionResult> auth([FromBody] User user)
        {
            var authResponse = await authService.findRequest(user.Id, user.Role);
            
            return Ok(authResponse);
        }

    }
}