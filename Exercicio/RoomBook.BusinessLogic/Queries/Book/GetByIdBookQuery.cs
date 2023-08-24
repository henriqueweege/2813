using Domain.Queries.Contracts;

namespace RoomBooking.Domain.Queries.Book;

public class GetByIdBookQuery : IGetByIdQuery
{
    public Guid Id { get; set; }
}
