using RoomBook.BusinessLogic.Commands.Book;
using RoomBooking.Domain.Commands.Book;
using RoomBooking.Domain.Converters;
using RoomBooking.Domain.Converters.Contracts;
using RoomBooking.Domain.Entities;
using RoomBooking.Domain.ValueObjects;

namespace Converters_UnitTests;

public class BookConverter_UnitTests
{
    private readonly IConverter<Book, CreateBookCommand, UpdateBookCommand> Converter;
    public BookConverter_UnitTests()
    {
        Converter = new BookConverter();
    }

    [Fact]
    public void GivenCreateCommand_ShouldCreateEntity()
    {
        //arrange
        var command = new CreateBookCommand() 
        {
            Email  = "email@mail",
            RoomId = Guid.NewGuid(),
            Day = DateTime.Now,
            CreditCard = new CreditCard()
            {
                Number = "number",
                Holder = "holder",
                Expiration = "expiration",
                Cvv = "cvv"
            }
        };

        //act-assert
        Assert.Throws<NotImplementedException>(() => Converter.ConvertFromCreateCommandToEntity(command));
    }

    [Fact]
    public void GivenUpdateCommand_EntitiesPropertiesShouldMatchCommand()
    {
        //arrange
        var email = "mail@email.com";
        var roomId = Guid.NewGuid();
        var date = DateTime.Now;
        var newEmail = "newmail@email.com";
        var newRoomId = Guid.NewGuid();
        var newDate = DateTime.Now.AddDays(1.0);


        var entityToUpdate = new Book(email, roomId, date);
        var command = new UpdateBookCommand()
        {
            Id = entityToUpdate.Id,
            Email = newEmail,
            RoomId = newRoomId,
            Date = newDate,
        };

        //act
        var entityUpdated = Converter.ConvertFromUpdateCommandToEntity(command, entityToUpdate);

        //assert
        Assert.Equal(entityToUpdate.Id.ToString(), entityUpdated.Id.ToString());
        Assert.NotEqual(email, entityUpdated.Email);
        Assert.NotEqual(roomId, entityUpdated.RoomId);
        Assert.NotEqual(date, entityUpdated.Date);

    }
}
