using Domain.Commands.Contracts;

namespace RoomBooking.Domain.Commands.Customer;

public class CreateCustomerCommand : ICreateCommand
{
    public string Email { get; set; }

}
