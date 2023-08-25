using MediatR;
using RoomBooking.BusinessLogic.Queries.Contracts;
using RoomBooking.Entities.Entities;

namespace RoomBooking.BusinessLogic.Queries.BookQueries;

public class GetByIdBookQuery : IGetByIdQuery, IRequest<QueryResult<Book>>
{
    public Guid Id { get; set; }
}
