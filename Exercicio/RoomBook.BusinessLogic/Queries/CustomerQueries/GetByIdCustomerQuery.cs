using MediatR;
using RoomBooking.BusinessLogic.Queries.Contracts;
using RoomBooking.Entities.Entities;

namespace RoomBooking.BusinessLogic.Queries.CustomerQueries;

public class GetByIdCustomerQuery : IGetByIdQuery, IRequest<QueryResult<Customer>>
{
    public Guid Id { get; set; }
}
