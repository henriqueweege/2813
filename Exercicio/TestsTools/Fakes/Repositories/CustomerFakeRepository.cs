using RoomBooking.Entities.Entities;
using RoomBooking.Infrastructure.DataAccess.Repositories.Contracts;
using TestsTools.Fakes.Repositories.Base;

namespace TestsTools.Fakes.Repositories;

public class CustomerFakeRepository : BaseFakeRepository<Customer>, ICustomerRepository
{
    public Customer? GetByEmail(string email)
        => Entities.FirstOrDefault(x => x.Email == email);
}
