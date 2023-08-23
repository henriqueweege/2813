using RoomBooking.Domain.Commands.Customer;
using RoomBooking.Domain.Converters.Contracts;
using RoomBooking.Domain.Entities;

namespace RoomBooking.Domain.Converters;

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
