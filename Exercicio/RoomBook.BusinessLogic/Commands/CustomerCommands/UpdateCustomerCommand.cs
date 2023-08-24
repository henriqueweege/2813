using MediatR;
using RoomBook.BusinessLogic.Commands.Contracts;
using RoomBooking.Entities.Entities;

namespace RoomBook.BusinessLogic.Commands.CustomerCommands;

public class UpdateCustomerCommand : IUpdateCommand, IRequest<CommandResult<Customer>>
{
    public Guid Id { get; set; }
    public string Email { get; set; }

}
