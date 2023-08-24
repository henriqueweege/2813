using RoomBook.BusinessLogic.Commands.CustomerCommands;
using RoomBook.BusinessLogic.Converters;
using RoomBook.BusinessLogic.Converters.Contracts;
using RoomBooking.Entities.Entities;

namespace Converters_UnitTests;

public class CustomerConverter_UnitTests
{
    private readonly IConverter<Customer, CreateCustomerCommand, UpdateCustomerCommand> Converter;
    public CustomerConverter_UnitTests()
    {
        Converter = new CustomerConverter();
    }

    [Fact]
    public void GivenCreateCommand_ShouldCreateEntity()
    {
        //arrange
        var command = new CreateCustomerCommand();
        command.Email = "mail@email.com";

        //act
        var entity = Converter.ConvertFromCreateCommandToEntity(command);

        //assert
        Assert.True(Guid.TryParse(entity.Id.ToString(), out _));
        Assert.NotNull(entity.Email);

    }

    [Fact]
    public void GivenUpdateCommand_EntitiesPropertiesShouldMatchCommand()
    {
        //arrange
        var email = "first@email.com";
        var entityToUpdate = new Customer(email);
        var command = new UpdateCustomerCommand();
        command.Email = "newmail@email.com";

        //act
        var entityUpdated = Converter.ConvertFromUpdateCommandToEntity(command, entityToUpdate);

        //assert
        Assert.Equal(entityToUpdate.Id.ToString(), entityUpdated.Id.ToString());
        Assert.NotEqual(email, entityUpdated.Email);

    }

}