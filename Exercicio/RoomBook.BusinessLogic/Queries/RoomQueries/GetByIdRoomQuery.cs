using MediatR;
using RoomBook.BusinessLogic.Queries.Contracts;
using RoomBooking.Entities.Entities;

namespace RoomBook.BusinessLogic.Queries.RoomQueries;

public class GetByIdRoomQuery : IGetByIdQuery, IRequest<QueryResult<Room>>
{
    public Guid Id { get; set; }
}
