using MediatR;
using RoomBooking.BusinessLogic.Commands.Contracts;
using RoomBooking.Entities.Entities;

namespace RoomBooking.BusinessLogic.Commands.CustomerCommands;

public class CreateCustomerCommand : ICreateCommand, IRequest<CommandResult<Customer>>
{
    public string Email { get; set; }

}
