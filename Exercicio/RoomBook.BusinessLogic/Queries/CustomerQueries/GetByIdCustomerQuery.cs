using MediatR;
using RoomBook.BusinessLogic.Queries.Contracts;
using RoomBooking.Entities.Entities;

namespace RoomBook.BusinessLogic.Queries.CustomerQueries;

public class GetByIdCustomerQuery : IGetByIdQuery, IRequest<QueryResult<Customer>>
{
    public Guid Id { get; set; }
}
