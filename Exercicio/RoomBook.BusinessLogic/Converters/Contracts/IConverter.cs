using RoomBooking.BusinessLogic.Commands.Contracts;
using RoomBooking.Entities.Entities.Base;

namespace RoomBooking.BusinessLogic.Converters.Contracts;

public interface IConverter<E, CC, UC> where E : Entity where CC : ICreateCommand where UC : IUpdateCommand
{
    public E ConvertFromCreateCommandToEntity(CC command);
    public E ConvertFromUpdateCommandToEntity(UC command, E entityToUpdate);
}
