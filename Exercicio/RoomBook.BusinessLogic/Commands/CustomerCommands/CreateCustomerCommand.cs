using MediatR;
using RoomBook.BusinessLogic.Commands.Contracts;
using RoomBooking.Entities.Entities;

namespace RoomBook.BusinessLogic.Commands.CustomerCommands;

public class CreateCustomerCommand : ICreateCommand, IRequest<CommandResult<Customer>>
{
    public string Email { get; set; }

}
