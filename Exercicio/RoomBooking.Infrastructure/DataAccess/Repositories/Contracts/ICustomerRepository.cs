using RoomBooking.Domain.DataAccess.Repositories.Base.Contracts;
using RoomBooking.Domain.Entities;

namespace RoomBooking.Domain.DataAccess.Repositories.Contracts;

public interface ICustomerRepository : IBaseRepository<Customer>
{
    public Customer? GetByEmail(string email);

}
