using MediatR;
using RoomBook.BusinessLogic.Queries.Contracts;
using RoomBooking.Entities.Entities;

namespace RoomBook.BusinessLogic.Queries.CustomerQueries;

public class GetAllCustomerQuery : IGetAllQuery, IRequest<QueryResult<Customer>>
{
}
