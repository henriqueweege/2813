using RoomBooking.Entities.Entities;
using RoomBooking.Infrastructure.DataAccess.Repositories.Base.Contracts;

namespace RoomBooking.Infrastructure.DataAccess.Repositories.Contracts;

public interface ICustomerRepository : IBaseRepository<Customer>
{
    public Customer? GetByEmail(string email);

}
