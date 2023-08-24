using Domain.Queries.Contracts;

namespace RoomBooking.Domain.Queries.Customer;

public class GetByIdCustomerQuery : IGetByIdQuery
{
    public Guid Id { get; set; }
}
