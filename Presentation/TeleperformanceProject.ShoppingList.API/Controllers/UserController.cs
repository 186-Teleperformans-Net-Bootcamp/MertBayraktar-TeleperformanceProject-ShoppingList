using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeleperformanceProject.ShoppingList.Application.Features.Commands.Users.UserLogin;
using TeleperformanceProject.ShoppingList.Application.Features.Commands.Users.UserRegister;
using TeleperformanceProject.ShoppingList.Persistence.Contexts;

namespace TeleperformanceProject.ShoppingList.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {

            _mediator = mediator;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> UserRegister([FromQuery] UserRegisterCommandRequest userRegisterCommandRequest)
        {
            UserRegisterCommandResponse response = await _mediator.Send(userRegisterCommandRequest);
            return Ok(response);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> UserLogin([FromQuery] UserLoginCommandRequest userLoginCommandRequest)
        {
            UserLoginCommandResponse response = await _mediator.Send(userLoginCommandRequest);
            return Ok(response);
        }
    }
}



