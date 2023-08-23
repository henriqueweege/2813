using Domain.Commands.Contracts;
using RoomBooking.Domain.ValueObjects;

namespace RoomBooking.Domain.Commands.Book;

public class CreateBookCommand : ICreateCommand
{
    public string Email { get; set; }
    public Guid RoomId { get; set; }
    public DateTime Day { get; set; }
    public CreditCard CreditCard { get; set; }
}
