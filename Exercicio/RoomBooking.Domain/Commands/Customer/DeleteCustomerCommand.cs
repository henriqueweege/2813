using Domain.Commands.Contracts;

namespace RoomBooking.Domain.Commands.Customer;

public class DeleteCustomerCommand : IDeleteCommand
{
    public Guid Id { get; set; }

}
