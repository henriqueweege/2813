using MediatR;
using Microsoft.AspNetCore.Mvc;
using RoomBook.BusinessLogic.Commands;
using RoomBook.BusinessLogic.Commands.BookCommands;
using RoomBook.BusinessLogic.Queries.BookQueries;
using RoomBooking.Entities.Entities;

namespace DependencyRoomBooking.Controllers;

[ApiController]
[Route("[controller]/[action]")]
#pragma warning disable 1591
public class BookController : ControllerBase
{
    /// <summary>
    /// Book a room.
    /// </summary>
    [Produces("application/json")]
    [ProducesResponseType(typeof(CommandResult<Book>), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(CommandResult<Book>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(CommandResult<Book>), StatusCodes.Status200OK)]
    [HttpPost]
    public IActionResult PostBook([FromBody] CreateBookCommand command, [FromServices] IMediator mediator)
        => Return(mediator.Send(command).Result);
    /// <summary>
    /// Get a book register by id.
    /// </summary>
    [Produces("application/json")]
    [ProducesResponseType(typeof(CommandResult<Book>), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(CommandResult<Book>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(CommandResult<Book>), StatusCodes.Status200OK)]
    [HttpGet]
    public IActionResult GetById([FromQuery] Guid id, [FromServices] IMediator mediator)
        => Return(mediator.Send(new GetByIdBookQuery() { Id = id}).Result);
    /// <summary>
    /// Get all book register.
    /// </summary>
    [Produces("application/json")]
    [ProducesResponseType(typeof(CommandResult<Book>), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(CommandResult<Book>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(CommandResult<Book>), StatusCodes.Status200OK)]
    [HttpGet]
    public IActionResult GetAll([FromServices] IMediator mediator)
        => Return(mediator.Send(new GetAllBookQuery()).Result);
    /// <summary>
    /// Update a book register.
    /// </summary>
    [Produces("application/json")]
    [ProducesResponseType(typeof(CommandResult<Book>), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(CommandResult<Book>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(CommandResult<Book>), StatusCodes.Status200OK)]
    [HttpPut]
    public IActionResult Put([FromBody] UpdateBookCommand command, [FromServices] IMediator mediator)
        => Return(mediator.Send(command).Result);
    /// <summary>
    /// Delete a book register.
    /// </summary>
    [Produces("application/json")]
    [ProducesResponseType(typeof(CommandResult<Book>), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(CommandResult<Book>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(CommandResult<Book>), StatusCodes.Status200OK)]
    [HttpDelete]
    public IActionResult Delete([FromBody] DeleteBookCommand command, [FromServices] IMediator mediator)
        => Return(mediator.Send(command).Result);
    private IActionResult Return(dynamic result)
    {
        if (result.Message.Contains("Ok"))
        {
            return Ok(result);
        }
        else if (result.Message.Contains("BadRequest"))
        {
            return BadRequest(result);
        }
        else if (result.Message.Contains("NoContent"))
        {
            return StatusCode(StatusCodes.Status204NoContent, result);
        }
        return StatusCode(StatusCodes.Status500InternalServerError, result);
    }
}