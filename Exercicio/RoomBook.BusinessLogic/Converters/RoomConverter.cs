using RoomBooking.BusinessLogic.Commands.RoomCommands;
using RoomBooking.BusinessLogic.Converters.Contracts;
using RoomBooking.Entities.Entities;

namespace RoomBooking.BusinessLogic.Converters;

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