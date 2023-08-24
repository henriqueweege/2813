using Domain.Commands.Contracts;

namespace RoomBooking.Domain.Commands.Customer;

public class CreateRoomCommand : ICreateCommand
{
    public string Name { get; set; }

}
