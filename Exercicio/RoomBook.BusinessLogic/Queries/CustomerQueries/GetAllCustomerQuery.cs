using MediatR;
using RoomBooking.BusinessLogic.Queries.Contracts;
using RoomBooking.Entities.Entities;

namespace RoomBooking.BusinessLogic.Queries.CustomerQueries;

public class GetAllCustomerQuery : IGetAllQuery, IRequest<QueryResult<Customer>>
{
}
