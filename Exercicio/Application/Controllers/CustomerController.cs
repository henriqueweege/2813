﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using RoomBooking.BusinessLogic.Commands;
using RoomBooking.BusinessLogic.Commands.CustomerCommands;
using RoomBooking.BusinessLogic.Queries.CustomerQueries;
using RoomBooking.Entities.Entities;

namespace DependencyRoomBooking.Controllers;

[ApiController]
[Route("[controller]/[action]")]
#pragma warning disable 1591
public class CustomerController : ControllerBase
{
    /// <summary>
    /// Create a customer.
    /// </summary>
    [Produces("application/json")]
    [ProducesResponseType(typeof(CommandResult<Customer>), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(CommandResult<Customer>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(CommandResult<Customer>), StatusCodes.Status200OK)]
    [HttpPost]
    public IActionResult PostCustomer([FromBody] CreateCustomerCommand command, [FromServices] IMediator mediator)
        => Return(mediator.Send(command).Result);
    /// <summary>
    /// Get customer by id.
    /// </summary>
    [Produces("application/json")]
    [ProducesResponseType(typeof(CommandResult<Customer>), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(CommandResult<Customer>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(CommandResult<Customer>), StatusCodes.Status200OK)]
    [HttpGet]
    public IActionResult GetById([FromQuery] Guid id, [FromServices] IMediator mediator)
        => Return(mediator.Send(new GetByIdCustomerQuery() { Id = id }).Result);
    /// <summary>
    /// Get all customers.
    /// </summary>
    [Produces("application/json")]
    [ProducesResponseType(typeof(CommandResult<Customer>), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(CommandResult<Customer>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(CommandResult<Customer>), StatusCodes.Status200OK)]
    [HttpGet]
    public IActionResult GetAll([FromServices] IMediator mediator)
        => Return(mediator.Send(new GetAllCustomerQuery()).Result);
    /// <summary>
    /// Update a customer.
    /// </summary>
    [Produces("application/json")]
    [ProducesResponseType(typeof(CommandResult<Customer>), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(CommandResult<Customer>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(CommandResult<Customer>), StatusCodes.Status200OK)]
    [HttpPut]
    public IActionResult Put([FromBody] UpdateCustomerCommand command, [FromServices] IMediator mediator)
        => Return(mediator.Send(command).Result);
    /// <summary>
    /// Delete a customer.
    /// </summary>
    [Produces("application/json")]
    [ProducesResponseType(typeof(CommandResult<Customer>), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(CommandResult<Customer>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(CommandResult<Customer>), StatusCodes.Status200OK)]
    [HttpDelete]
    public IActionResult Delete([FromBody] DeleteCustomerCommand command, [FromServices] IMediator mediator)
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