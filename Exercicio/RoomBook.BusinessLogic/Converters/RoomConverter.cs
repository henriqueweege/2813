using RoomBooking.Domain.Commands.Customer;
using RoomBooking.Domain.Converters.Contracts;
using RoomBooking.Domain.Entities;

namespace RoomBooking.Domain.Converters;

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