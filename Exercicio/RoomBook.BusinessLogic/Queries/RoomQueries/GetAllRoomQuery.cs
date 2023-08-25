using MediatR;
using RoomBooking.BusinessLogic.Queries.Contracts;
using RoomBooking.Entities.Entities;

namespace RoomBooking.BusinessLogic.Queries.RoomQueries;

public class GetAllRoomQuery : IGetAllQuery, IRequest<QueryResult<Room>>
{
}
