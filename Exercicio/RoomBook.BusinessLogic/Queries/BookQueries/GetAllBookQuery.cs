using MediatR;
using RoomBooking.BusinessLogic.Queries.Contracts;
using RoomBooking.Entities.Entities;

namespace RoomBooking.BusinessLogic.Queries.BookQueries;

public class GetAllBookQuery : IGetAllQuery, IRequest<QueryResult<Book>>
{
}
