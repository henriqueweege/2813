using Domain.Queries.Contracts;

namespace RoomBooking.Domain.Queries.Room;

public class GetByIdRoomQuery : IGetByIdQuery
{
    public Guid Id { get; set; }
}
