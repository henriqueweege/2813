using MediatR;
using RoomBook.BusinessLogic.Commands.Contracts;
using RoomBooking.Entities.Entities;

namespace RoomBook.BusinessLogic.Commands.CustomerCommands;

public class DeleteCustomerCommand : IDeleteCommand, IRequest<CommandResult<Customer>>
{
    public Guid Id { get; set; }

}
