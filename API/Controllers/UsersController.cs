using Application.Commands;
using Application.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API_2.Controllers
{
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("User")]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var query = new GetUserListQuery();
            var users = await _mediator.Send(query);

            return Ok(users);
        }
        [HttpPost ("CreateUser")]
        public async Task<IActionResult> CreateProduct(CreateUserCommand command)
        {
            var productId = await _mediator.Send(command);
            return Ok(productId);
        }

    }
}

