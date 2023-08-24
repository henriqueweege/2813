using MediatR;
using RoomBook.BusinessLogic.Queries.Contracts;
using RoomBooking.Entities.Entities;

namespace RoomBook.BusinessLogic.Queries.BookQueries;

public class GetByIdBookQuery : IGetByIdQuery, IRequest<QueryResult<Book>>
{
    public Guid Id { get; set; }
}
