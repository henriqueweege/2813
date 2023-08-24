using MediatR;
using RoomBook.BusinessLogic.Commands.Contracts;
using RoomBooking.Entities.Entities;

namespace RoomBook.BusinessLogic.Commands.RoomCommands;

public class CreateRoomCommand : ICreateCommand, IRequest<CommandResult<Room>>
{
    public string Name { get; set; }

}
