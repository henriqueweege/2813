using MediatR;
using RoomBook.BusinessLogic.Commands;
using RoomBook.BusinessLogic.Queries.Contracts;
using RoomBooking.Entities.Entities;

namespace RoomBook.BusinessLogic.Queries.BookQueries;

public class GetAllBookQuery : IGetAllQuery, IRequest<QueryResult<Book>>
{
}
