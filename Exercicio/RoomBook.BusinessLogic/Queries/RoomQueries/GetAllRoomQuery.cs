using MediatR;
using RoomBook.BusinessLogic.Queries.Contracts;
using RoomBooking.Entities.Entities;

namespace RoomBook.BusinessLogic.Queries.RoomQueries;

public class GetAllRoomQuery : IGetAllQuery, IRequest<QueryResult<Room>>
{
}
