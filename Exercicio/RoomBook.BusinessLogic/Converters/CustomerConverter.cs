using RoomBooking.BusinessLogic.Commands.CustomerCommands;
using RoomBooking.BusinessLogic.Converters.Contracts;
using RoomBooking.Entities.Entities;

namespace RoomBooking.BusinessLogic.Converters;

public class CustomerConverter : IConverter<Customer, CreateCustomerCommand, UpdateCustomerCommand>
{
    public Customer ConvertFromCreateCommandToEntity(CreateCustomerCommand command)
     => new Customer(command.Email);

    public Customer ConvertFromUpdateCommandToEntity(UpdateCustomerCommand command, Customer entityToUpdate)
    {
        entityToUpdate.ChangeEmail(command.Email);
        return entityToUpdate;
    }
}
