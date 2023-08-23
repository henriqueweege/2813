using RoomBooking.Domain.Commands.Book;
using RoomBooking.Domain.Converters.Contracts;
using RoomBooking.Domain.Entities;

namespace RoomBooking.Domain.Converters;

public class BookConverter : IConverter<Book, CreateBookCommand, UpdateBookCommand>
{
    public Book ConvertFromCreateCommandToEntity(CreateBookCommand command)
     => throw new NotImplementedException();

    public Book ConvertFromUpdateCommandToEntity(UpdateBookCommand command, Book entityToUpdate)
    {
        entityToUpdate.ChangeEmail(command.Email);
        entityToUpdate.ChangeRoomId(command.RoomId);
        entityToUpdate.ChangeDate(command.Date);
        return entityToUpdate;
    }
}
