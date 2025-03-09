using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Application.Commands;
using UserManagement.Application.Queries;

namespace UserManagementAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator){
            _mediator = mediator;
        } 

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetUserById), new { id = result.Id }, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var result = await _mediator.Send(new GetUserByIdQuery(id));
            return result == null ? NotFound() : Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _mediator.Send(new GetAllUsersQuery());
            return Ok(result);
        }
    }

}