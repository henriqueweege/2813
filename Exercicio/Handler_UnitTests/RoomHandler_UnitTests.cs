using RoomBooking.Domain.Commands.Customer;
using RoomBooking.Domain.Converters;
using RoomBooking.Domain.Entities;
using RoomBooking.Domain.Handlers;
using RoomBooking.Domain.Queries.Room;
using TestsTools.Fakes.Repositories;

namespace Handler_UnitTests;

public class RoomHandler_UnitTests
{
    private readonly RoomFakeRepository FakeRepository;
    private readonly RoomConverter Converter;
    private readonly RoomHandler Handler;
    private readonly string Name;

    public RoomHandler_UnitTests()
    {
        FakeRepository = new();
        Converter = new();
        Handler = new(Converter, FakeRepository);
        Name = "name";
    }

    [Fact]
    public void GivenCorrectCreateCommand_ShouldHandleSuccessfully()
    {

        //arrange
        var command = new CreateRoomCommand()
        {
            Name = Name
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

        var saved = FakeRepository.Save(new Room(Name));

        var command = new UpdateRoomCommand()
        {
            Id = saved.Id,
            Name = "New Name"
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
        var saved = FakeRepository.Save(new Room(Name));
        var command = new DeleteRoomCommand()
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
        var saved = FakeRepository.Save(new Room(Name));
        var query = new GetAllRoomQuery();

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
        var saved = FakeRepository.Save(new Room(Name));
        var query = new GetByIdRoomQuery()
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
