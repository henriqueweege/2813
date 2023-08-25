using MediatR;
using RoomBooking.BusinessLogic.Commands.Contracts;
using RoomBooking.Entities.Entities;

namespace RoomBooking.BusinessLogic.Commands.BookCommands;

public class DeleteBookCommand : IDeleteCommand, IRequest<CommandResult<Book>>
{
    public Guid Id { get; set; }
}
