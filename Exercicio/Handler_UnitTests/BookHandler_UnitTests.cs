using RoomBook.BusinessLogic.Commands.BookCommands;
using RoomBook.BusinessLogic.Converters;
using RoomBook.BusinessLogic.Handlers;
using RoomBook.BusinessLogic.Queries.BookQueries;
using RoomBooking.Entities.Entities;
using RoomBooking.Entities.ValueObjects;
using RoomBooking.InfrastructureServices.PaymentServices.Contract;
using TestsTools.Fakes.InfrastructureServices;
using TestsTools.Fakes.Repositories;

namespace Handler_UnitTests;

public class BookHandler_UnitTests
{
    private readonly BookFakeRepository _bookFakeRepository;
    private readonly CustomerFakeRepository _customerFakeRepository;
    private readonly RoomFakeRepository _roomFakeRepository;
    private readonly BookConverter _converter;
    private readonly BookHandler _handler;
    private readonly IPaymentServices _paymentServices;
    private readonly string _email;
    private readonly Guid _roomId;
    private readonly DateTime _date;

    public BookHandler_UnitTests()
    {
        _bookFakeRepository = new();
        _customerFakeRepository = new();
        _converter = new();
        _roomFakeRepository = new();
        _paymentServices = new FakePaymentServices();
        _handler = new BookHandler(_converter, _bookFakeRepository, _customerFakeRepository, _roomFakeRepository, _paymentServices);
        _email = "email@mail.com";
        _roomId = Guid.NewGuid();
        _date = DateTime.Now;
    }

    [Fact]
    public void GivenCorrectCreateCommandAndContext_ShouldHandleSuccessfully()
    {

        //arrange
        _customerFakeRepository.Save(new Customer(_email));
        var room = _roomFakeRepository.Save(new Room("name"));
        var command = new CreateBookCommand()
        {
            Email = _email,
            RoomId = room.Id,
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
    public void GivenInvalidEmail_ShouldHandleSuccessfully()
    {

        //arrange
        _customerFakeRepository.Save(new Customer(_email));
        var command = new CreateBookCommand()
        {
            Email = "invalid@email.com",
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
        Assert.True(!created.Success);
        Assert.Null(created.Result);
    }

    [Fact]
    public void GivenCorrectUpdateCommand_ShouldHandleSuccessfully()
    {
        //arrange
        var email = "mail@email.com";
        _customerFakeRepository.Save(new Customer(email));
        var room = _roomFakeRepository.Save(new Room("name"));
        var date = DateTime.Now;
        var newEmail = "newmail@email.com";
        _customerFakeRepository.Save(new Customer(newEmail));

        var newRoom = _roomFakeRepository.Save(new Room("name"));

        var newDate = DateTime.Now.AddDays(1.0);


        var entityToUpdate = _bookFakeRepository.Save(new Book(email, room.Id, date));
        var command = new UpdateBookCommand()
        {
            Id = entityToUpdate.Id,
            Email = newEmail,
            RoomId = newRoom.Id,
            Day = newDate,
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
        var saved = _bookFakeRepository.Save(new Book(_email, _roomId, _date));
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
        var saved = _bookFakeRepository.Save(new Book(_email, _roomId, _date));
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
        var saved = _bookFakeRepository.Save(new Book(_email, _roomId, _date));
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
