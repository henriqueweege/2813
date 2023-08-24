using MediatR;
using RoomBook.BusinessLogic.Commands.Contracts;
using RoomBooking.Entities.Entities;

namespace RoomBook.BusinessLogic.Commands.RoomCommands;

public class DeleteRoomCommand : IDeleteCommand, IRequest<CommandResult<Room>>
{
    public Guid Id { get; set; }

}
