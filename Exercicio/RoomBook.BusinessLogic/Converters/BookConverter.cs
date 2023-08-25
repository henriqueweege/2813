using RoomBooking.BusinessLogic.Commands.BookCommands;
using RoomBooking.BusinessLogic.Converters.Contracts;
using RoomBooking.Entities.Entities;

namespace RoomBooking.BusinessLogic.Converters;

public class BookConverter : IConverter<Book, CreateBookCommand, UpdateBookCommand>
{
    public Book ConvertFromCreateCommandToEntity(CreateBookCommand command)
        => new Book(command.Email, command.RoomId, command.Day);


    public Book ConvertFromUpdateCommandToEntity(UpdateBookCommand command, Book entityToUpdate)
    {
        entityToUpdate.ChangeEmail(command.Email);
        entityToUpdate.ChangeRoomId(command.RoomId);
        entityToUpdate.ChangeDate(command.Day);
        return entityToUpdate;
    }
}
