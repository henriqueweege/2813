using Domain.Commands.Contracts;
using RoomBooking.Domain.Entities.Base;

namespace RoomBooking.Domain.Converters.Contracts;

public interface IConverter<E, CC, UC> where E : Entity where CC: ICreateCommand where UC : IUpdateCommand
{
    public E ConvertFromCreateCommandToEntity(CC command);
    public E ConvertFromUpdateCommandToEntity(UC command, E entityToUpdate);
}
