using MediatR;
using RoomBooking.BusinessLogic.Queries.Contracts;
using RoomBooking.Entities.Entities;

namespace RoomBooking.BusinessLogic.Queries.RoomQueries;

public class GetByIdRoomQuery : IGetByIdQuery, IRequest<QueryResult<Room>>
{
    public Guid Id { get; set; }
}
