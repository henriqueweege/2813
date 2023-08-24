using MediatR;
using RoomBook.BusinessLogic.Commands.Contracts;
using RoomBooking.Entities.Entities;

namespace RoomBook.BusinessLogic.Commands.BookCommands;

public class UpdateBookCommand : IUpdateCommand, IRequest<CommandResult<Book>>
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public Guid RoomId { get; set; }
    public DateTime Day { get; set; }
}
