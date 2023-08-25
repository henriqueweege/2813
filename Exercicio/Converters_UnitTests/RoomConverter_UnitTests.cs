using RoomBooking.BusinessLogic.Commands.RoomCommands;
using RoomBooking.BusinessLogic.Converters;
using RoomBooking.BusinessLogic.Converters.Contracts;
using RoomBooking.Entities.Entities;

namespace Converters_UnitTests;

public class RoomConverter_UnitTests
{
    private readonly IConverter<Room, CreateRoomCommand, UpdateRoomCommand> Converter;
    public RoomConverter_UnitTests()
    {
        Converter = new RoomConverter();
    }

    [Fact]
    public void GivenCreateCommand_ShouldCreateEntity()
    {
        //arrange
        var command = new CreateRoomCommand();
        command.Name = "name";

        //act
        var entity = Converter.ConvertFromCreateCommandToEntity(command);

        //assert
        Assert.True(Guid.TryParse(entity.Id.ToString(), out _));
        Assert.NotNull(entity.Name);

    }

    [Fact]
    public void GivenUpdateCommand_EntitiesPropertiesShouldMatchCommand()
    {
        //arrange
        var name = "original name";
        var entityToUpdate = new Room(name);
        var command = new UpdateRoomCommand();
        command.Name = "new name";

        //act
        var entityUpdated = Converter.ConvertFromUpdateCommandToEntity(command, entityToUpdate);

        //assert
        Assert.Equal(entityToUpdate.Id.ToString(), entityUpdated.Id.ToString());
        Assert.NotEqual(name, entityUpdated.Name);

    }
}
