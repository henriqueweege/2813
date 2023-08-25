using MediatR;
using RoomBooking.BusinessLogic.Commands.Contracts;
using RoomBooking.Entities.Entities;

namespace RoomBooking.BusinessLogic.Commands.RoomCommands;

public class UpdateRoomCommand : IUpdateCommand, IRequest<CommandResult<Room>>
{
    public Guid Id { get; set; }
    public string Name { get; set; }

}
