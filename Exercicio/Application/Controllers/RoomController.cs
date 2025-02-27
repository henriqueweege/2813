﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using RoomBooking.BusinessLogic.Commands;
using RoomBooking.BusinessLogic.Commands.RoomCommands;
using RoomBooking.BusinessLogic.Queries.RoomQueries;
using RoomBooking.Entities.Entities;

namespace DependencyRoomBooking.Controllers;

[ApiController]
[Route("[controller]/[action]")]
#pragma warning disable 1591
public class RoomController : ControllerBase
{
    /// <summary>
    /// Create a room.
    /// </summary>
    [Produces("application/json")]
    [ProducesResponseType(typeof(CommandResult<Room>), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(CommandResult<Room>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(CommandResult<Room>), StatusCodes.Status200OK)]
    [HttpPost]
    public IActionResult PostRoom([FromBody] CreateRoomCommand command, [FromServices] IMediator mediator)
        => Return(mediator.Send(command).Result);
    /// <summary>
    /// Get room by id.
    /// </summary>
    [Produces("application/json")]
    [ProducesResponseType(typeof(CommandResult<Room>), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(CommandResult<Room>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(CommandResult<Room>), StatusCodes.Status200OK)]
    [HttpGet]
    public IActionResult GetById([FromQuery] Guid id, [FromServices] IMediator mediator)
        => Return(mediator.Send(new GetByIdRoomQuery() { Id = id }).Result);
    /// <summary>
    /// Get all rooms.
    /// </summary>
    [Produces("application/json")]
    [ProducesResponseType(typeof(CommandResult<Room>), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(CommandResult<Room>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(CommandResult<Room>), StatusCodes.Status200OK)]
    [HttpGet]
    public IActionResult GetAll([FromServices] IMediator mediator)
        => Return(mediator.Send(new GetAllRoomQuery()).Result);
    /// <summary>
    /// Update room.
    /// </summary>
    [Produces("application/json")]
    [ProducesResponseType(typeof(CommandResult<Room>), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(CommandResult<Room>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(CommandResult<Room>), StatusCodes.Status200OK)]
    [HttpPut]
    public IActionResult Put([FromBody] UpdateRoomCommand command, [FromServices] IMediator mediator)
        => Return(mediator.Send(command).Result);
    /// <summary>
    /// Delete room.
    /// </summary>
    [Produces("application/json")]
    [ProducesResponseType(typeof(CommandResult<Room>), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(CommandResult<Room>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(CommandResult<Room>), StatusCodes.Status200OK)]
    [HttpDelete]
    public IActionResult Delete([FromBody] DeleteRoomCommand command, [FromServices] IMediator mediator)
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