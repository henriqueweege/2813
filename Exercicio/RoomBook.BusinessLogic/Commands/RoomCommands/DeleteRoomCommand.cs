using MediatR;
using RoomBooking.BusinessLogic.Commands.Contracts;
using RoomBooking.Entities.Entities;

namespace RoomBooking.BusinessLogic.Commands.RoomCommands;

public class DeleteRoomCommand : IDeleteCommand, IRequest<CommandResult<Room>>
{
    public Guid Id { get; set; }

}
