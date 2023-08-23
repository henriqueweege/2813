using Domain.Commands;
using RoomBooking.Domain.Commands.Customer;
using RoomBooking.Domain.Converters;
using RoomBooking.Domain.Converters.Contracts;
using RoomBooking.Domain.DataAccess.Repositories.Contracts;
using RoomBooking.Domain.Entities;
using RoomBooking.Domain.Handlers.Base;
using RoomBooking.Domain.Queries.Room;

namespace RoomBooking.Domain.Handlers;

public class RoomHandler : CRUDHandler<Room, RoomConverter, 
                                       CreateRoomCommand, UpdateRoomCommand, DeleteRoomCommand,
                                       GetAllRoomQuery, GetByIdRoomQuery>
{


    public RoomHandler(IConverter<Room, CreateRoomCommand, UpdateRoomCommand> converter, IRoomRepository repository) : base(converter, repository)
    {
    }
}
