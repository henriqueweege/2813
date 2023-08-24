using MediatR;
using RoomBook.BusinessLogic.Commands.Contracts;
using RoomBooking.Entities.Entities;
using RoomBooking.Entities.ValueObjects;

namespace RoomBook.BusinessLogic.Commands.BookCommands;

public class CreateBookCommand : ICreateCommand, IRequest<CommandResult<Book>>
{
    public string Email { get; set; }
    public Guid RoomId { get; set; }
    public DateTime Day { get; set; }
    public CreditCard CreditCard { get; set; }
}
