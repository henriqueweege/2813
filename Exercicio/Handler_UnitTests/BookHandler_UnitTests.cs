using RoomBooking.Domain.Commands.Book;
using RoomBooking.Domain.Converters;
using RoomBooking.Domain.Entities;
using RoomBooking.Domain.Handlers;
using RoomBooking.Domain.Queries.Book;
using RoomBooking.Domain.ValueObjects;
using TestsTools.Fakes.Repositories;

namespace Handler_UnitTests;

public class BookHandler_UnitTests
{
    private readonly BookFakeRepository _fakeRepository;
    private readonly BookConverter _converter;
    private readonly BookHandler _handler;
    private readonly string _email;
    private readonly Guid _roomId;
    private readonly DateTime _date;

    public BookHandler_UnitTests()
    {
        _fakeRepository = new();
        _converter = new();
        _handler = new(_converter, _fakeRepository);
        _email = "email@mail.com";
        _roomId = Guid.NewGuid();
        _date = DateTime.Now;
    }

    [Fact]
    public void GivenCorrectCreateCommand_ShouldHandleSuccessfully()
    {

        //arrange
        var command = new CreateBookCommand()
        {
            Email = _email,
            RoomId = _roomId,
            Day = _date,
            CreditCard = new CreditCard()
            {
                Number = "number",
                Holder = "holder",
                Expiration = "expiration",
                Cvv = "cvv"
            }
        };

        //act
        var created = _handler.Handle(command);

        //assert
        Assert.True(created.Success);
        Assert.NotNull(created.Result);
    }

    [Fact]
    public void GivenCorrectUpdateCommand_ShouldHandleSuccessfully()
    {
        //arrange
        var email = "mail@email.com";
        var roomId = Guid.NewGuid();
        var date = DateTime.Now;
        var newEmail = "newmail@email.com";
        var newRoomId = Guid.NewGuid();
        var newDate = DateTime.Now.AddDays(1.0);


        var entityToUpdate = _fakeRepository.Save(new Book(email, roomId, date));
        var command = new UpdateBookCommand()
        {
            Id = entityToUpdate.Id,
            Email = newEmail,
            RoomId = newRoomId,
            Date = newDate,
        };

        //act
        var updated = _handler.Handle(command);

        //assert
        Assert.True(updated.Success);
        Assert.NotNull(updated.Result);
    }

    [Fact]
    public void GivenCorrectDeleteCommand_ShouldHandleSuccessfully()
    {

        //arrange
        var saved = _fakeRepository.Save(new Book(_email, _roomId, _date));
        var command = new DeleteBookCommand()
        {
            Id = saved.Id,
        };

        //act
        var deleted = _handler.Handle(command);

        //assert
        Assert.True(deleted.Success);
        Assert.Null(deleted.Result);
    }

    [Fact]
    public void GivenCorrectGetAllQuery_ShouldHandleSuccessfully()
    {

        //arrange
        var saved = _fakeRepository.Save(new Book(_email, _roomId, _date));
        var query = new GetAllBookQuery();

        //act
        var all = _handler.Handle(query);

        //assert
        Assert.True(all.Success);
        Assert.NotNull(all.Result);
    }

    [Fact]
    public void GivenCorrectGetByIdQuery_ShouldHandleSuccessfully()
    {

        //arrange
        var saved = _fakeRepository.Save(new Book(_email, _roomId, _date));
        var query = new GetByIdBookQuery()
        {
            Id = saved.Id
        };

        //act
        var byId = _handler.Handle(query);

        //assert
        Assert.True(byId.Success);
        Assert.NotNull(byId.Result);
    }
}
