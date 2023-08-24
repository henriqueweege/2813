using Domain.Commands.Contracts;

namespace RoomBooking.Domain.Commands.Customer;

public class UpdateCustomerCommand : IUpdateCommand
{
    public Guid Id { get; set; }
    public string Email { get; set; }

}
