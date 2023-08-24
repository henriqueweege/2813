using MediatR;
using RoomBook.BusinessLogic.Commands.Contracts;
using RoomBooking.Entities.Entities;

namespace RoomBook.BusinessLogic.Commands.BookCommands;

public class DeleteBookCommand : IDeleteCommand, IRequest<CommandResult<Book>>
{
    public Guid Id { get; set; }
}
