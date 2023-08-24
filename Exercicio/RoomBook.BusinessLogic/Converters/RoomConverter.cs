using RoomBook.BusinessLogic.Commands.RoomCommands;
using RoomBook.BusinessLogic.Converters.Contracts;
using RoomBooking.Entities.Entities;

namespace RoomBook.BusinessLogic.Converters;

public class RoomConverter : IConverter<Room, CreateRoomCommand, UpdateRoomCommand>
{
    public Room ConvertFromCreateCommandToEntity(CreateRoomCommand command)
     => new Room(command.Name);

    public Room ConvertFromUpdateCommandToEntity(UpdateRoomCommand command, Room entityToUpdate)
    {
        entityToUpdate.ChangeName(command.Name);
        return entityToUpdate;
    }
}