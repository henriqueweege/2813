using MediatR;
using RoomBooking.BusinessLogic.Commands.Contracts;
using RoomBooking.Entities.Entities;

namespace RoomBooking.BusinessLogic.Commands.RoomCommands;

public class CreateRoomCommand : ICreateCommand, IRequest<CommandResult<Room>>
{
    public string Name { get; set; }

}
