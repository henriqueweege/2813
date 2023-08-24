using RoomBooking.Domain.Commands.Customer;
using RoomBooking.Domain.Entities;
using RoomBooking.Domain.Handlers;
using RoomBooking.Domain.Handlers.Base;
using RoomBooking.Domain.Queries.Customer;
using RoomBooking.DomainServices.Converters;
using TestsTools.Fakes.Repositories;

namespace Handler_UnitTests;

public class CustomerHandler_UnitTests
{
    private readonly CustomerFakeRepository FakeRepository;
    private readonly CustomerConverter Converter;
    private readonly CustomerHandler Handler;
    private readonly string Email;

    public CustomerHandler_UnitTests()
    {
        FakeRepository= new ();
        Converter= new ();
        Handler = new(Converter, FakeRepository);
        Email = "mail@email.com";
    }

    [Fact]
    public void GivenCorrectCreateCommand_ShouldHandleSuccessfully()
    {

        //arrange
        var command = new CreateCustomerCommand()
        {
            Email = Email
        };

        //act
        var created = Handler.Handle(command);

        //assert
        Assert.True(created.Success);
        Assert.NotNull(created.Result);
    }

    [Fact]
    public void GivenCorrectUpdateCommand_ShouldHandleSuccessfully()
    {

        //arrange

        var saved = FakeRepository.Save(new Customer(Email));

        var command = new UpdateCustomerCommand()
        {
            Id = saved.Id,
            Email = "newmail@email.com"
        };

        //act
        var updated = Handler.Handle(command);

        //assert
        Assert.True(updated.Success);
        Assert.NotNull(updated.Result);
    }

    [Fact]
    public void GivenCorrectDeleteCommand_ShouldHandleSuccessfully()
    {

        //arrange
        var saved = FakeRepository.Save(new Customer(Email));
        var command = new DeleteCustomerCommand()
        { 
            Id = saved.Id,
        };

        //act
        var deleted = Handler.Handle(command);

        //assert
        Assert.True(deleted.Success);
        Assert.Null(deleted.Result);
    }

    [Fact]
    public void GivenCorrectGetAllQuery_ShouldHandleSuccessfully()
    {

        //arrange
        var saved = FakeRepository.Save(new Customer(Email));
        var query = new GetAllCustomerQuery();

        //act
        var all = Handler.Handle(query);

        //assert
        Assert.True(all.Success);
        Assert.NotNull(all.Result);
    }

    [Fact]
    public void GivenCorrectGetByIdQuery_ShouldHandleSuccessfully()
    {

        //arrange
        var saved = FakeRepository.Save(new Customer(Email));
        var query = new GetByIdCustomerQuery()
        {
            Id = saved.Id
        };

        //act
        var byId = Handler.Handle(query);

        //assert
        Assert.True(byId.Success);
        Assert.NotNull(byId.Result);
    }

}