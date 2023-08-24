using Domain.Commands.Contracts;

namespace RoomBooking.Domain.Commands.Customer;

public class UpdateRoomCommand : IUpdateCommand
{
    public Guid Id { get; set; }
    public string Name { get; set; }

}
