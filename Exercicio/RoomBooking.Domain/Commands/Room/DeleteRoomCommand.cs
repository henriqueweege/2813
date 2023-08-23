using Domain.Commands.Contracts;

namespace RoomBooking.Domain.Commands.Customer;

public class DeleteRoomCommand : IDeleteCommand
{
    public Guid Id { get; set; }

}
