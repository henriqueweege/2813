using MediatR;
using RoomBooking.BusinessLogic.Commands.Contracts;
using RoomBooking.Entities.Entities;

namespace RoomBooking.BusinessLogic.Commands.CustomerCommands;

public class DeleteCustomerCommand : IDeleteCommand, IRequest<CommandResult<Customer>>
{
    public Guid Id { get; set; }

}
