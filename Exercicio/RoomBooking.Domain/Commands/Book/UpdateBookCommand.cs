using Domain.Commands.Contracts;

namespace RoomBooking.Domain.Commands.Book;

public class UpdateBookCommand : IUpdateCommand
{
    public Guid Id { get; set; }
    public string Email { get;  set; }
    public Guid RoomId { get;  set; }
    public DateTime Date { get;  set; }

}
